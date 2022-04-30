using System;
using System.Net;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;
using Mirai.Net.Utils.Scaffolds;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var con = new ConnectConfig
            {
                HttpAddress = "",
                WebsocketAddress = ""
            };
            return;
            var exit = new ManualResetEvent(false);
            
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                VerifyKey = "1145141919810",
                QQ = "1590454991"
            };
            
            await bot.LaunchAsync();
            
            bot.MessageReceived
                .OfType<GroupMessageReceiver>()
                .Subscribe(async r =>
                {
                    if (r.MessageChain.GetPlainMessage() == "/send")
                    {
                        var voice = new VoiceMessage
                        {
                            Path = "",
                            Url = "",
                            VoiceId = "",
                            Base64 = ""
                        };

                        await r.SendMessageAsync(voice);
                    }
                });

            Console.WriteLine("launched");
            exit.WaitOne();
        }
    }
}