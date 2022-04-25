using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var exit = new ManualResetEvent(false);
            
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                VerifyKey = "1145141919810",
                QQ = "1590454991"
            };
            
            await bot.LaunchAsync();
            
            bot.MessageReceived
                .OfType<GroupMessageReceiver>()
                .Subscribe(async r =>
                {
                    if (r.MessageChain.GetPlainMessage() == "/send")
                    {
                        await r.SendMessageAsync("the true message will be revealed in 5 seconds");
                        DispatchUtils.ExecuteScheduledActionAsync(5000, async () =>
                        {
                            await r.SendMessageAsync("my key is: 1145141919810");
                        });
                    }
                });

            Console.WriteLine("launched");
            exit.WaitOne();
        }

        private static async Task Execute(GroupMessageReceiver receiver)
        {
            await receiver.SendMessageAsync("Executed!");
        }
    }
}