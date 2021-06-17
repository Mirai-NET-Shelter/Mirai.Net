using System;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Websocket.Client;

namespace Mirai.Net.Sessions
{
    /// <summary>
    /// 这是用来描述一个Mirai机器人的类
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

        /// <summary>
        /// 绑定的账号, singleMode 模式下为空, 非 singleMode 下新建连接不可为空
        /// </summary>
        public string QQ { get; set; }

        public async Task Launch()
        {
            var url = new Uri($@"ws://{Address}");
            var factor = new Func<ClientWebSocket>(() =>
            {
                var ws = new ClientWebSocket();

                ws.Options.SetRequestHeader("verifyKey", VerifyKey);
                ws.Options.SetRequestHeader("qq", QQ);
                // ws.Options.SetRequestHeader("sessionKey", null);

                return ws;
            });

            using var client = new WebsocketClient(url, factor);

            client.MessageReceived.Subscribe(Console.WriteLine);
            
            await client.StartOrFail();
        }
    }
}