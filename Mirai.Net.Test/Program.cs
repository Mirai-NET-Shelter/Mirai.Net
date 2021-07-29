using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
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
            // var exit = new ManualResetEvent(false);
            // using var bot = new MiraiBot
            // {
            //     Address = "localhost:8080",
            //     QQ = 2672886221,
            //     VerifyKey = "1145141919810"
            // };
            //
            // await bot.Launch();
            // Console.WriteLine(await bot.GetPluginVersion());
            //
            // exit.WaitOne(TimeSpan.FromSeconds(30));

            MyClass c = new MyClass2
            {
                Type = "MyClass2",
                Name = "jack"
            };

            Console.WriteLine(c);
        }

        public abstract class  MyClass
        {
            public abstract string Type { get; set; }

            public override string ToString()
            {
                return this.ToJsonString();
            }
        }
        
        public class MyClass2 : MyClass
        {
            public string Name { get; set; }
            public override string Type { get; set; } = "MyClass2";
        }

        public class MyClass3 : MyClass
        {
            public override string Type { get; set; } = "MyClass3";

            public int Id { get; set; }
        }
        
        public class MyClass4 : MyClass
        {
            public override string Type { get; set; } = "MyClass4";

            public bool IsShit { get; set; }
        }
    }
}