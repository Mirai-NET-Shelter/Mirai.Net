using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var watch = new Stopwatch();
            watch.Start();
            
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                VerifyKey = "1145141919810",
                QQ = "2672886221"
            };

            await bot.LaunchAsync();
            
            watch.Stop();

            Console.WriteLine($"Time: {watch.ElapsedMilliseconds}");
        }
    }
}