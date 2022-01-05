using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Flurl;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Exceptions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using Websocket.Client;

namespace Mirai.Net.Sessions;

/// <summary>
///     mirai-api-http机器人描述
/// </summary>
public class MiraiBot : IDisposable
{
    public async void Dispose()
    {
        await ReleaseAsync();
        _client.Dispose();
    }

    #region Exposed

    public async Task LaunchAsync()
    {
        Instance = this;


        await VerifyAsync();
        await BindAsync();
        await StartWebsocketListenerAsync();
    }

    #endregion

    #region Properties

    /// <summary>
    ///     最后一个启动的MiraiBot实例
    /// </summary>
    public static MiraiBot Instance { get; set; }

    internal string HttpSessionKey { get; set; }

    private string _address;
    private string _qq;
    private WebsocketClient _client;

    /// <summary>
    ///     mirai-api-http本地服务器地址，比如：localhost:114514
    ///     <exception cref="InvalidAddressException">传入错误的地址将会抛出异常</exception>
    /// </summary>
    public string Address
    {
        get => _address.TrimEnd('/').Empty("http://").Empty("https://");
        set
        {
            if (!value.Contains(":")) throw new InvalidAddressException($"错误的地址: {value}");

            var split = value.Split(':');

            if (split.Length != 2) throw new InvalidAddressException($"错误的地址: {value}");
            if (!split.Last().IsInteger()) throw new InvalidAddressException($"错误的地址: {value}");

            _address = value;
        }
    }

    /// <summary>
    ///     建立连接的QQ账号
    /// </summary>
    public string QQ
    {
        get => _qq;
        set => _qq = value.IsIntegerOrThrow(new InvalidQQException("错误的QQ号"));
    }

    /// <summary>
    ///     Mirai.Net总是需要一个VerifyKey
    /// </summary>
    public string VerifyKey { get; set; }

    public Lazy<IEnumerable<Group>> Groups => 
        new(() => AccountManager.GetGroupsAsync().GetAwaiter().GetResult());
    
    public Lazy<IEnumerable<Friend>> Friends => 
        new(() => AccountManager.GetFriendsAsync().GetAwaiter().GetResult());

    #endregion

    #region Handlers

    [JsonIgnore] public IObservable<EventBase> EventReceived => _eventReceivedSubject.AsObservable();

    private readonly Subject<EventBase> _eventReceivedSubject = new();

    [JsonIgnore] public IObservable<MessageReceiverBase> MessageReceived => _messageReceivedSubject.AsObservable();

    private readonly Subject<MessageReceiverBase> _messageReceivedSubject = new();

    [JsonIgnore] public IObservable<string> UnknownMessageReceived => _unknownMessageReceived.AsObservable();

    private readonly Subject<string> _unknownMessageReceived = new();

    [JsonIgnore]
    public IObservable<WebSocketCloseStatus> DisconnectionHappened => _disconnectionHappened.AsObservable();

    private readonly Subject<WebSocketCloseStatus> _disconnectionHappened = new();

    #endregion

    #region Http adapter private helpers

    /// <summary>
    ///     发送验证请求，获得未激活的session key
    /// </summary>
    /// <returns></returns>
    private async Task VerifyAsync()
    {
        var result = await HttpEndpoints.Verify.PostJsonAsync(new
        {
            verifyKey = VerifyKey
        }, false);

        HttpSessionKey = result.Fetch("session");
    }

    /// <summary>
    ///     激活session key
    /// </summary>
    private async Task BindAsync()
    {
        _ = await HttpEndpoints.Bind.PostJsonAsync(new
        {
            sessionKey = HttpSessionKey,
            qq = QQ
        }, false);
    }

    /// <summary>
    ///     释放已激活的session
    /// </summary>
    private async Task ReleaseAsync()
    {
        _ = await HttpEndpoints.Release.PostJsonAsync(new
        {
            sessionKey = HttpSessionKey,
            qq = QQ
        }, false);
    }

    #endregion

    #region Websocket adapter private helpers

    /// <summary>
    ///     启动websocket监听
    /// </summary>
    private async Task StartWebsocketListenerAsync()
    {
        var url = $"ws://{Address}/all"
            .SetQueryParam("verifyKey", VerifyKey)
            .SetQueryParam("qq", QQ)
            .ToUri();

        _client = new WebsocketClient(url)
        {
            IsReconnectionEnabled = false
        };

        await _client.StartOrFail();

        _client.DisconnectionHappened
            .Subscribe(x => { _disconnectionHappened.OnNext(x.CloseStatus ?? WebSocketCloseStatus.Empty); });

        _client.MessageReceived
            .Where(message => message.MessageType == WebSocketMessageType.Text)
            .Subscribe(message =>
            {
                var type = GetRespondMessageType(message);
                var data = message.Text.Fetch("data");

                switch (type)
                {
                    case WebsocketMessageTypes.Message:
                        var receiver = ReflectionUtils.GetMessageReceiverBase(data);

                        var messageChain = data
                            .Fetch("messageChain")
                            .ToJArray()
                            .Select(token => ReflectionUtils.GetMessageBase(token.ToString()))
                            .ToList();

                        receiver.MessageChain = messageChain;

                        _messageReceivedSubject.OnNext(receiver);
                        break;
                    case WebsocketMessageTypes.Event:
                        _eventReceivedSubject.OnNext(ReflectionUtils.GetEventBase(data));
                        break;
                    case WebsocketMessageTypes.Unknown:
                        _unknownMessageReceived.OnNext(data);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
    }

    /// <summary>
    ///     获取websocket收到的消息是什么类型的
    /// </summary>
    /// <param name="message"></param>
    /// <returns>消息，事件，未知</returns>
    private static WebsocketMessageTypes GetRespondMessageType(ResponseMessage message)
    {
        if (message.MessageType != WebSocketMessageType.Text || message.Text.IsNullOrEmpty())
            return WebsocketMessageTypes.Unknown;

        try
        {
            var json = message.Text.Fetch("data").ToJObject();

            if (!json.ContainsKey("type"))
                return WebsocketMessageTypes.Unknown;

            return json.Fetch("type").Contains("Message")
                ? WebsocketMessageTypes.Message
                : WebsocketMessageTypes.Event;
        }
        catch
        {
            return WebsocketMessageTypes.Unknown;
        }
    }

    #endregion
}