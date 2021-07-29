using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;
using Websocket.Client;

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
                QQ = 2672886221,
                VerifyKey = "1145141919810"
            };
            
            await bot.Launch();
            Console.WriteLine(await bot.GetPluginVersion());

            exit.WaitOne(TimeSpan.FromSeconds(30));
        }

        enum MyEnum
        {
            [Description("t1")]
            Test1,
            Test2,
            Test3
        }
    }
}