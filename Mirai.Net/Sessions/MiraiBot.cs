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
using Mirai.Net.Utils;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using Websocket.Client;

namespace Mirai.Net.Sessions
{
    /// <summary>
    /// mirai-api-http机器人描述
    /// </summary>
    public class MiraiBot : IDisposable
    {
        #region Properties

        /// <summary>
        /// 最后一个启动的MiraiBot实例
        /// </summary>
        internal static MiraiBot Instance { get; set; }
        
        internal string HttpSessionKey { get; set; }

        private string _address;
        private string _qq;
        private WebsocketClient _client;

        /// <summary>
        /// mirai-api-http本地服务器地址，比如：localhost:114514
        /// <exception cref="InvalidAddressException">传入错误的地址将会抛出异常</exception>
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
        /// 建立连接的QQ账号
        /// </summary>
        public string QQ
        {
            get => _qq;
            set => _qq = value.IsIntegerOrThrow(new InvalidQQException("错误的QQ号"));
        }

        /// <summary>
        /// Mirai.Net总是需要一个VerifyKey
        /// </summary>
        public string VerifyKey { get; set; }
        
        #endregion
        
        #region Exposed

        public async Task LaunchAsync()
        {
            Instance = this;

            await Task.WhenAll(Task.Run(async () =>
            {
                await VerifyAsync();
                await BindAsync();
            }), StartWebsocketListenerAsync());
        }

        #endregion

        #region Handlers

        [JsonIgnore] public IObservable<EventBase> EventReceived => _eventReceivedSubject.AsObservable();

        private readonly Subject<EventBase> _eventReceivedSubject = new();

        [JsonIgnore] public IObservable<MessageReceiverBase> MessageReceived => _messageReceivedSubject.AsObservable();

        private readonly Subject<MessageReceiverBase> _messageReceivedSubject = new();
        
        [JsonIgnore] public IObservable<string> UnknownMessageReceived => _unknownMessageReceived.AsObservable();

        private readonly Subject<string> _unknownMessageReceived = new();

        #endregion
        
        #region Http adapter private helpers

        /// <summary>
        /// 发送验证请求，获得未激活的session key
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
        /// 激活session key
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
        /// 释放已激活的session
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
        /// 启动websocket监听
        /// </summary>
        private async Task StartWebsocketListenerAsync()
        {
            var url = $"ws://{Address}/all"
                .SetQueryParam("verifyKey", VerifyKey)
                .SetQueryParam("qq", QQ)
                .ToUri();

            _client = new WebsocketClient(url);

            _client.MessageReceived
                .Where(message => message.MessageType == WebSocketMessageType.Text)
                .Subscribe(message =>
                {
                    var type = GetRespondMessageType(message);
                    var data = message.Text.Fetch("data");
                    
                    switch (type)
                    {
                        case WebsocketMessageTypes.Message:
                            var receiver = GetMessageReceiverBase(data);

                            var messageChain = data
                                .Fetch("messageChain")
                                .ToJArray()
                                .Select(token => GetMessageBase(token.ToString()))
                                .ToList();

                            receiver.MessageChain = messageChain;

                            _messageReceivedSubject.OnNext(receiver);
                            break;
                        case WebsocketMessageTypes.Event:
                            _eventReceivedSubject.OnNext(GetEventBase(data));
                            break;
                        case WebsocketMessageTypes.Unknown:
                            _unknownMessageReceived.OnNext(data);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });

            await _client.StartOrFail();
        }

        /// <summary>
        /// 获取websocket收到的消息是什么类型的
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

        /// <summary>
        /// 默认消息接收器实例
        /// </summary>
        private static readonly IEnumerable<MessageReceiverBase> MessageReceiverBases = ReflectionUtils.GetDefaultInstances<MessageReceiverBase>(
            "Mirai.Net.Data.Messages.Receivers");
        
        /// <summary>
        /// 默认消息实例
        /// </summary>
        private static readonly IEnumerable<MessageBase> MessageBases =
            ReflectionUtils.GetDefaultInstances<MessageBase>("Mirai.Net.Data.Messages.Concretes");
        
        /// <summary>
        /// 默认事件实例
        /// </summary>
        private static readonly IEnumerable<EventBase> EventBases =
            ReflectionUtils.GetDefaultInstances<EventBase>("Mirai.Net.Data.Events.Concretes");

        /// <summary>
        /// 根据json动态解析正确的消息接收器子类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static MessageReceiverBase GetMessageReceiverBase(string data)
        {
            var root = JsonConvert.DeserializeObject<MessageReceiverBase>(data);

            return JsonConvert.DeserializeObject(data,
                MessageReceiverBases.First(receiver => receiver.Type == root!.Type)
                    .GetType()) as MessageReceiverBase;
        }
        
        /// <summary>
        /// 根据json动态解析对应的消息子类
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static MessageBase GetMessageBase(string data)
        {
            var root = JsonConvert.DeserializeObject<MessageBase>(data);

            return JsonConvert.DeserializeObject(data,
                MessageBases.First(message => message.Type == root!.Type)
                    .GetType()) as MessageBase;
        }

        /// <summary>
        /// 根据json动态解析对应的事件子类 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static EventBase GetEventBase(string data)
        {
            var root = JsonConvert.DeserializeObject<EventBase>(data);

            return JsonConvert.DeserializeObject(data,
                EventBases.First(message => message.Type == root!.Type)
                    .GetType()) as EventBase;
        }

        #endregion

        public async void Dispose()
        {
            await ReleaseAsync();
            _client.Dispose();
        }
    }
}