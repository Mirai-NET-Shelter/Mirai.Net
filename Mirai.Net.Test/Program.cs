using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Flurl;
using Mirai.Net.Data.Events.Concretes.Message;
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
                QQ = "2672886221"
            };

            await bot.LaunchAsync();

            bot.EventReceived
                .OfType<AtEvent>()
                .Subscribe(at =>
                {
                    Console.WriteLine(at.Receiver.ToJsonString());
                });
            
            bot.MessageReceived
                .OfType<GroupMessageReceiver>()
                .Subscribe(async receiver =>
                {
                    if (receiver.MessageChain.OfType<FileMessage>().Any())
                    {
                        var file = receiver.MessageChain.OfType<FileMessage>().First();

                        await receiver.SendGroupMessageAsync($"File received: {file.Name}");
                    }
                });

            exit.WaitOne();
        }
    }
}