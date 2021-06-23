using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Events;
using Mirai.Net.Listeners;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Websocket.Client;

namespace Mirai.Net.Sessions
{
    /// <summary>
    /// Mirai机器人
    /// </summary>
    public class MiraiBot
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
            var url = new Uri($@"ws://{Address}/all?verifyKey={VerifyKey}&qq={QQ}");
            var exit = new ManualResetEvent(false);

            using var client = new WebsocketClient(url);

            client.MessageReceived.Subscribe(s =>
            {
                if (s.IsEvent())
                {
                    if (EventListeners is {Count: > 0})
                    {
                        foreach (var listener in EventListeners)
                        {
                            var json = s.Text.ToJObject().Fetch("data");
                            var entity = json.ConvertToConcreteEventArgs();

                            if (listener.Executors.Any(x => x == entity.Type))
                            {
                                listener.Execute(entity);
                            }
                        }
                    }
                }
                else
                {
                    // if (MessageListeners is {Count: > 0})
                    // {
                    //     foreach (var listener in MessageListeners)
                    //     {
                    //         var json = s.Text.ToJObject().Fetch("data");
                    //         var entity = json.ConvertToConcreteEventArgs();
                    //
                    //         if (listener.Executors.Any(x => x == entity.Type))
                    //         {
                    //             listener.Execute(entity);
                    //         }
                    //     }
                    // }
                }
            });
            
            await client.StartOrFail();

            exit.WaitOne();
        }
    }
}