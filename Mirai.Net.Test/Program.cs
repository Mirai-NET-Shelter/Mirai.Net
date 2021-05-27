using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;
//TODO: Edit unused modify to internal
namespace Mirai.Net.Test
{
    public class Program
    {
        public static async Task Main()
        {
            var b = new PlainMessage
            {
                Text = "114514",
            };

            Console.WriteLine(b.ToJson());
            
            // Bot.Session = new MiraiSession
            // {
            //     Host = "127.0.0.1",
            //     Port = "2334",
            //     Key = "232511772e8745e0bd697f1dfb72f748",
            //     QQ = "2672886221"
            // };;
            // await Bot.Launch();
            //
            // Console.WriteLine("Connected!");
            // Console.WriteLine(await Bot.GetPluginVersion());
            // await Task.Delay(5000);
            //
            // await Bot.Terminate();
            // Console.WriteLine("Disconnected!");
        }
    }
}