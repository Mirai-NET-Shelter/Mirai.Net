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
            var mirai = new MiraiSession
            {
                Host = "127.0.0.1",
                Port = "2334",
                Key = "68d5cbe220cf4ab08b55abf66c8786e5",
                QQ = "1590454991"
            };

            await mirai.Connect();

            Console.WriteLine("Connected!");

            await Task.Delay(5000);

            await mirai.Disconnect();
            Console.WriteLine("Disconnected!");
        }
    }

    class MyClass
    {
        public string Name { get; set; }
        public string Identify { get; set; }
    }
}