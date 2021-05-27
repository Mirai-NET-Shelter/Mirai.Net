using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Messengers.Concrete;
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
            Bot.Session = new MiraiSession
            {
                Host = "127.0.0.1",
                Port = "2334",
                Key = "232511772e8745e0bd697f1dfb72f748",
                QQ = "2672886221"
            };;
            await Bot.Launch();
            
            Console.WriteLine("Connected!");
            Console.WriteLine(await Bot.GetPluginVersion());

            var messenger = new TempMessenger("1590454991", "389105053");
            var callback = await messenger.Send(new PlainMessage {Text = "Hello, World!"});

            Console.WriteLine(callback.MessageId);
            await Task.Delay(1000);

            await messenger.Send(callback.MessageId, new PlainMessage {Text = "Hi, I got a gift for you"});

            await Bot.Terminate();
            Console.WriteLine("Disconnected!");
        }
    }
}