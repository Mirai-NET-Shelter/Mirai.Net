using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Data.Messages.Enums;
using Mirai.Net.Messengers.Concrete;
using Mirai.Net.Messengers.MediaUploader;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json;
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
                Key = "68d5cbe220cf4ab08b55abf66c8786e5",
                QQ = "2672886221"
            };;
            await Bot.Launch();
                    
            Console.WriteLine("Connected!");
            Console.WriteLine(await Bot.GetPluginVersion());
            
            var result = await ImageUploader.Upload(@"C:\Users\ahpx\Desktop\Test\ahpx.png");

            Console.WriteLine(result.ImageId);

            var msg = new GroupMessenger("809830266");

            await msg.Send(new ImageMessage(result.ImageId, ImageMessageType.Id));
            
            await Bot.Terminate();
            Console.WriteLine("Disconnected!");
        }
    }
}