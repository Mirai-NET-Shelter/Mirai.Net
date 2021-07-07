using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Events;
using Mirai.Net.Listeners;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Websocket.Client;

namespace Mirai.Net.Sessions
{
    /// <summary>
    /// Mirai机器人
    /// </summary>
    public class MiraiBot : IDisposable
    {
        /// <summary>
        /// Mirai.Net总是需要一个VerifyKey
        /// </summary>
        public string VerifyKey { get; set; }

        /// <summary>
        /// 新建连接 或 singleMode 模式下为空, 通过已有 sessionKey 连接时不可为空
        /// </summary>
        public string SessionKey { get; set; }

        /// <summary>
        /// 比如：localhost:114514
        /// </summary>
        public string Address { get; set; }

        public List<IEventListener> EventListeners { get; set; } = new List<IEventListener>();
        public List<IMessageListener> MessageListeners { get; set; } = new List<IMessageListener>();

        /// <summary>
        /// 绑定的账号, singleMode 模式下为空, 非 singleMode 下新建连接不可为空
        /// </summary>
        public string QQ { get; set; }

        /// <summary>
        /// 启动Websocket监听
        /// </summary>
        public async Task Launch()
        {
            await LaunchHttpListener();
            await LaunchWebSocketListener();
        }

        #region Http

        /// <summary>
        /// 获取mirai-http-api插件的版本
        /// </summary>
        /// <returns></returns>
        public async Task<string> GetPluginVersion()
        {
            var url = $"http://{Address}/about";
            var response = await HttpUtilities.Get(url);

            response.EnsureSuccess();

            return response.ToJObject().Fetch("data.version");
        }

        private async Task LaunchHttpListener()
        {
            await Verify();
            await Bind();
        }

        /// <summary>
        /// 通过verifyKey验证sessionKey
        /// </summary>
        private async Task Verify()
        {
            var url = $"http://{Address}/verify";
            var content = new
            {
                verifyKey = VerifyKey
            }.ToJsonString();

            var response = await HttpUtilities.PostJson(url, content);

            response.EnsureSuccess();

            SessionKey = response.ToJObject().Fetch("session");
        }

        /// <summary>
        /// 把sessionKey绑定到指定的bot
        /// </summary>
        private async Task Bind()
        {
            var url = $"http://{Address}/bind";
            var content = new
            {
                sessionKey = SessionKey,
                qq = QQ
            }.ToJsonString();

            var response = await HttpUtilities.PostJson(url, content);

            response.EnsureSuccess();
        }

        /// <summary>
        /// 释放bot请求的资源
        /// </summary>
        private async Task Release()
        {
            var url = $"http://{Address}/release";
            var content = new
            {
                sessionKey = SessionKey,
                qq = QQ
            }.ToJsonString();

            var response = await HttpUtilities.PostJson(url, content);

            response.EnsureSuccess();
        }

        #endregion

        #region Websocket

        private WebsocketClient _client;

        private async Task LaunchWebSocketListener()
        {
            var url = new Uri($@"ws://{Address}/all?verifyKey={VerifyKey}&qq={QQ}");

            _client = new WebsocketClient(url);

            _client.MessageReceived
                .Where(x => !string.IsNullOrEmpty(x.Text))
                .Where(x => x.IsEvent() || x.IsMessage())
                .Subscribe(s =>
            {
                if (s.IsEvent())
                {
                    if (EventListeners != null && EventListeners.Count > 0)
                    {
                        foreach (var listener in EventListeners)
                        {
                            var json = s.Text.ToJObject().Fetch("data");
                            var entity = json.ConvertToConcreteEventArgs();

                            if (listener.Executors.Any(x => x == entity.Type))
                            {
                                listener.Execute(entity, this);
                            }
                        }
                    }
                }
                else if (s.IsMessage())
                {
                    if (MessageListeners != null && MessageListeners.Count > 0)
                    {
                        foreach (var listener in MessageListeners)
                        {
                            var json = s.Text.ToJObject().Fetch("data");
                            var entity = json.ConvertToConcreteMessageArgs();
                            entity.Chain = json.ToJObject()["messageChain"]?.ToObject<JArray>()!
                                .Select(x => x.ToString().ConvertToConcreteMessage());

                            if (listener.Executors.Any(x => x == entity.Type))
                            {
                                listener.Execute(entity, this);
                            }
                        }
                    }
                }
            });

            await _client.StartOrFail();
        }

        #endregion

        public async void Dispose()
        {
            _client.Dispose();

            await Release();
        }
    }
}