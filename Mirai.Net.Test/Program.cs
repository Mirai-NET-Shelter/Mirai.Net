using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Flurl;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var watch = new Stopwatch();
            var exit = new ManualResetEvent(false);
            watch.Start();
            
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                VerifyKey = "1145141919810",
                QQ = "2672886221"
            };
            
            await bot.LaunchAsync();
            
            watch.Stop();
            Console.WriteLine($"Start time: {watch.ElapsedMilliseconds}");
            
            watch.Restart();

            await MessageManager.SendGroupMessage("556962429", "Hello, World!");
            
            bot.MessageReceived.Subscribe(async x =>
            {
                if (x is GroupMessageReceiver receiver)
                {
                    foreach (var messageBase in receiver.MessageChain)
                    {
                        if (messageBase is PlainMessage { Text: "/hello" })
                        {
                            var newWatch = new Stopwatch();
                            newWatch.Start();
                            await MessageManager.SendGroupMessage("556962429", "Hello, World!");
                            
                            newWatch.Stop();

                            Console.WriteLine("Command respond time: " + newWatch.ElapsedMilliseconds);
                        }
                    }
                }
            });
            
            watch.Stop();

            Console.WriteLine($"Message time: {watch.ElapsedMilliseconds}");
            exit.WaitOne(TimeSpan.FromMinutes(1));
        }
    }
}