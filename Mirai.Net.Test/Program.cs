using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Flurl;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils;
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
            var json = new
            {
                test = 1,
                test2 = 3
            }.ToJsonString();

            var v2 = json.Fetch("test2");
            
            
            await bot.LaunchAsync();

            bot.MessageReceived
                .OfType<GroupMessageReceiver>()
                .Subscribe(async receiver =>
                {
                    if (receiver.MessageChain.OfType<PlainMessage>().Any(x => x.Text == "/temp"))
                    {
                        await receiver.SendGroupMessageAsync(new VoiceMessage
                        {
                            Path = @"D:\Softwares\silk2mp3-full\b3.silk"
                        });
                    }
                });

            exit.WaitOne();
        }
    }
}