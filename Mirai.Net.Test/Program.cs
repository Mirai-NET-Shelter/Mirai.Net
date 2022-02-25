using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Scaffolds;

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

            bot.MessageReceived.OfType<GroupMessageReceiver>().Subscribe(async x =>
            {
                if (x.MessageChain.GetPlainMessage() == "/send")
                {
                    await x.SendMessageAsync(new MessageChainBuilder()
                        .At(x.Sender)
                        .Plain("这是一个测试")
                        .ImageFromId("{AB9BA7E2-DAF6-F959-AD74-CD9BFA794729}.jpg")
                        .Build());
                }
            });
            
            exit.WaitOne();
        }
    }
}