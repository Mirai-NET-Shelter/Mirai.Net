using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl.Http;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json.Linq;
using Timer = System.Timers.Timer;

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
                        var localPath = @"C:\Users\ahpx\Desktop\6S__`V)7J7E8(1S[R(ZD`VT.jpg";
                        var file = await FileManager.UploadFileAsync(r.GroupId, localPath);

                        await r.SendMessageAsync($"The file has been uploaded. \r\n{file.ToJsonString()}");
                    }
                });

            exit.WaitOne();
        }

        private static async Task Execute(GroupMessageReceiver receiver)
        {
            await receiver.SendMessageAsync("Executed!");
        }
    }
}