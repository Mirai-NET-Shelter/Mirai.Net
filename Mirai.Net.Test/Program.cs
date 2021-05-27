using System;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Data.Messages.Enums;
using Mirai.Net.Data.Messengers.Media;
using Mirai.Net.Messengers.Concrete;
using Mirai.Net.Messengers.MediaUploader;
using Mirai.Net.Sessions;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;
using WebSocket = WebSocketSharp.WebSocket;

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

            var ws = new WebSocket(
                $"ws://{Bot.Session.Host}:{Bot.Session.Port}/message?sessionKey={Bot.Session.SessionKey}");

            ws.OnMessage += (sender, args) =>
            {
                string r = string.Empty;
                try
                {
                    r = args.Data.ToJObject().GetPropertyValue("messageChain");
                }
                catch
                {
                    Console.WriteLine($"Exception: {args.Data.ToJson()}");
                }
                
                foreach (var token in JArray.Parse(r))
                {
                    Console.WriteLine(token.ToString());
                }
            };
            
            ws.Connect();

            while (true)
            {
                if (Console.ReadLine() != "exit") continue;
                
                await Bot.Terminate();
                Console.WriteLine("Disconnected!");
                
                return;
            }
        }
    }
}