using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Test
{
    public class Program
    {
        public static async Task Main()
        {
            var session = new MiraiSession
            {
                Host = "127.0.0.1",
                Port = "2334",
                Key = "232511772e8745e0bd697f1dfb72f748",
                QQ = "2672886221"
            };

            Bot.Session = session;
            await Bot.Launch();
            
            Console.WriteLine("Connected!");
            Console.WriteLine(await Bot.GetPluginVersion());
            await Task.Delay(5000);
            
            await Bot.Terminate();
            Console.WriteLine("Disconnected!");
        }

        public static async void T1()
        {
            await Task.Delay(1000);
            var a = 100;

            Console.WriteLine(a / 0);
        }

        public static async Task T2()
        {
            await Task.Delay(1000);
            var a = 100;

            Console.WriteLine(a / 0);
        }
    }

    class MyClass
    {
        public string Name { get; set; }
        public string Identify { get; set; }
    }
}