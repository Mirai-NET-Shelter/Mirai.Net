using System;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Manganese.Array;
using Manganese.Text;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;
using Mirai.Net.Utils.Scaffolds;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var exit = new ManualResetEvent(false);
            
            var bot = new MiraiBot
            {
                Address = new ConnectConfig
                {
                    HttpAddress = new ConnectConfig.AdapterConfig("localhost", "8080"),
                    WebsocketAddress = new ConnectConfig.AdapterConfig("localhost", "8080")
                },
                VerifyKey = "1145141919810",
                QQ = "1590454991"
            };
            
            await bot.LaunchAsync();

            bot.MessageReceived
                .SubscribeGroupMessageAsync(async r =>
                {
                    if (r.MessageChain.GetPlainMessage() == "/t")
                    {
                        await r.SendMessageAsync("Echo");
                    }
                });

            Console.WriteLine("launched");
            exit.WaitOne();
        }
    }
}