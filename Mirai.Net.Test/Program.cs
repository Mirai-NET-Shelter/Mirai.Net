using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
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

            bot.MessageReceived.OfType<GroupMessageReceiver>()
                .Subscribe(async receiver =>
                {
                    MessageChain messageChain = new PlainMessage("Test") + new AtMessage("114514");
                    messageChain += new PlainMessage("12");
                    messageChain += new MessageChainBuilder().At("awd").Build();

                    await messageChain.SendToAsync(receiver);
                });
            
            // bot.MessageReceived
            //     .OfType<GroupMessageReceiver>()
            //     .Subscribe(async x =>
            //     {
            //         var msg = x.MessageChain.GetPlainMessage();
            //         if (msg.Contains("什么服")
            //             && new[]{1,2,5,7,8,9}.Any(i => msg.StartsWith(i.ToString())))
            //         {
            //             await x.SendMessageAsync(new MessageChainBuilder().At(x.Sender)
            //                 .Plain(" 9开头是港澳台服\r\n")
            //                 .Plain("8开头是亚服(日服也算亚服)\r\n")
            //                 .Plain("7开头是欧服\r\n")
            //                 .Plain("6开头是美服\r\n")
            //                 .Plain("5开头是渠道服服(b服，小米服等)\r\n")
            //                 .Plain("1和2开头是官服")
            //                 .Build());
            //         }
            //     });
            
            exit.WaitOne();
        }

        private static async Task Execute(GroupMessageReceiver receiver)
        {
            await receiver.SendMessageAsync("Executed!");
        }
    }
}