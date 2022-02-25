using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
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
                Address = "101.35.130.232:8080",
                VerifyKey = "1145141919810",
                QQ = "1590454991"
            };
            
            await bot.LaunchAsync();

            bot.MessageReceived.OfType<GroupMessageReceiver>().Subscribe(async x =>
            {
                if (x.MessageChain.GetPlainMessage() == "/send")
                {
                    await x.SendMessageAsync();
                }
            });
            
            exit.WaitOne();
        }
    }
}