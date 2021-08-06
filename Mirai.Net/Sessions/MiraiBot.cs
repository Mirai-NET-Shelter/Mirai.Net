using System;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using AHpx.Extensions.Utils;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json;
using Websocket.Client;

namespace Mirai.Net.Sessions
{
    /// <summary>
    ///     Mirai机器人
    /// </summary>
    public class MiraiBot : IDisposable
    {
        #region Exposed

        /// <param name="address">地址，比如localhost:8080</param>
        /// <param name="verifyKey">验证密钥，Mirai.Net总是需要一个验证密钥</param>
        /// <param name="qq">bot的qq号</param>
        public MiraiBot(string address = null, string verifyKey = null, long qq = default)
        {
            _address = address;
            VerifyKey = verifyKey;
            QQ = qq;
        }

        /// <summary>
        ///     启动bot对象
        /// </summary>
        public async Task Launch()
        {
            try
            {
                await LaunchHttpAdapter();
                await LaunchWebsocketAdapter();

                MiraiBotFactory.Bot = this;
            }
            catch (Exception e)
            {
                throw new Exception($"启动失败: {e.Message}\n{this}", e);
            }
        }

        #endregion

        #region Adapter launcher

        /// <summary>
        ///     认证http
        /// </summary>
        private async Task LaunchHttpAdapter()
        {
            await VerifyHttp();
            await BindHttp();
        }

        private WebsocketClient _client;

        /// <summary>
        ///     启动websocket监听
        /// </summary>
        private async Task LaunchWebsocketAdapter()
        {
            var url = this.GetUrl(WebsocketEndpoints.All);

            _client = new WebsocketClient(new Uri(url));

            _client
                .MessageReceived
                .Where(x => x.MessageType == WebSocketMessageType.Text)
                .Subscribe(message =>
                {
                    var type = message.GetNotificationType();
                    var data = message.Text.Fetch("data");

                    switch (type)
                    {
                        case WebsocketAdapterNotifications.Message:
                            var messageBase = data.GetMessageReceiverBase();
                            var messageChain = data
                                .Fetch("messageChain")
                                .ToJArray()
                                .Select(token => token.ToString().GetMessageBase())
                                .ToList();

                            messageBase.MessageChain = messageChain;

                            _messageReceivedSubject.OnNext(messageBase);
                            break;
                        case WebsocketAdapterNotifications.Event:
                            var eventBase = data.GetEventBase();
                            _eventReceivedSubject.OnNext(eventBase);
                            break;
                        case WebsocketAdapterNotifications.Unknown:
                            Console.WriteLine($"received unknown notification: {data}");
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                });

            await _client.StartOrFail();
        }

        #endregion

        #region Property definitions

        [JsonIgnore] public IObservable<EventBase> EventReceived => _eventReceivedSubject.AsObservable();

        private readonly Subject<EventBase> _eventReceivedSubject = new();

        [JsonIgnore] public IObservable<MessageReceiverBase> MessageReceived => _messageReceivedSubject.AsObservable();

        private readonly Subject<MessageReceiverBase> _messageReceivedSubject = new();

        /// <summary>
        ///     Mirai.Net总是需要一个VerifyKey
        /// </summary>
        public string VerifyKey { get; set; }

        /// <summary>
        ///     新建连接 或 singleMode 模式下为空, 通过已有 sessionKey 连接时不可为空
        /// </summary>
        internal string HttpSessionKey { get; set; }

        private string _address;

        /// <summary>
        ///     比如：localhost:114514
        /// </summary>
        public string Address
        {
            get => _address.TrimEnd('/').Empty("http://").Empty("https://");
            set
            {
                if (!value.Contains(":")) throw new Exception($"错误的地址: {value}");

                var split = value.Split(':');

                if (split.Length != 2) throw new Exception($"错误的地址: {value}");
                if (!split.Last().IsInteger()) throw new Exception($"错误的地址: {value}");

                _address = value;
            }
        }

        /// <summary>
        ///     绑定的账号, singleMode 模式下为空, 非 singleMode 下新建连接不可为空
        /// </summary>
        public long QQ { get; set; }

        #endregion

        #region Http adapter

        /// <summary>
        ///     调用端点: /verify，返回一个新的session key
        /// </summary>
        /// <returns>返回sessionKey</returns>
        private async Task VerifyHttp()
        {
            var url = this.GetUrl(HttpEndpoints.Verify);
            var response = await HttpUtilities.PostJsonAsync(url, new
            {
                verifyKey = VerifyKey
            }.ToJsonString());

            this.EnsureSuccess(response);

            var content = await response.FetchContent();

            HttpSessionKey = content.Fetch("session");
        }

        /// <summary>
        ///     调用端点：/bind，将当前对象的qq好绑定的指定的sessionKey
        /// </summary>
        private async Task BindHttp()
        {
            var url = this.GetUrl(HttpEndpoints.Bind);
            var response = await HttpUtilities.PostJsonAsync(url, new
            {
                sessionKey = HttpSessionKey,
                qq = QQ
            }.ToJsonString());

            this.EnsureSuccess(response);
        }

        /// <summary>
        ///     调用端口：/release，释放bot的资源占用
        /// </summary>
        private async Task ReleaseHttp()
        {
            var url = this.GetUrl(HttpEndpoints.Release);
            var response = await HttpUtilities.PostJsonAsync(url, new
            {
                sessionKey = HttpSessionKey,
                qq = QQ
            }.ToJsonString());

            this.EnsureSuccess(response);
        }

        #endregion

        #region Diagnose stuff

        /// <summary>
        ///     重写了默认的ToString方法，本质上是替代为ToJsonString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.ToJsonString();
        }

        public async void Dispose()
        {
            _client?.Dispose();
            _eventReceivedSubject.OnCompleted();
            await ReleaseHttp();
        }

        #endregion
    }
}