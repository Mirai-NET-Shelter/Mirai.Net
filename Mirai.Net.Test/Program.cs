using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 2672886221,
                VerifyKey = "1145141919810"
            };
            
            Console.WriteLine(await bot.GetPluginVersion());

            var exit = new ManualResetEvent(false);
            await bot.Launch();
            
            exit.WaitOne(TimeSpan.FromSeconds(31));
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