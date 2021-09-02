using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Flurl;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Scaffolds;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            var trigger = new CommandTriggerAttribute("ahpx", equalName: true);
            var chain = new MessageBase[]
            {
                new PlainMessage("/ahpax"),
                new PlainMessage("/ahpzx"),
                new JsonMessage{Json = "lawdlkawd/ahpxawjduawdj"}
            };

            Console.WriteLine(chain.CanExecute(trigger));

            // var watch = new Stopwatch();
            // var exit = new ManualResetEvent(false);
            // watch.Start();
            //
            // using var bot = new MiraiBot
            // {
            //     Address = "localhost:8080",
            //     VerifyKey = "1145141919810",
            //     QQ = "2672886221"
            // };
            //
            // await bot.LaunchAsync();
            //
            // watch.Stop();
            // Console.WriteLine($"Start time: {watch.ElapsedMilliseconds}");
            //
            // var re = await FileManager.UploadVoiceAsync(
            //     @"C:\Users\ahpx\Documents\Tencent Files\2933170747\Audio\U)$I}EJE)JDXEK7LZETKX(G.amr");
            //
            //
            // Console.WriteLine(re.ToJsonString());
            //
            // exit.WaitOne(TimeSpan.FromMinutes(1));
        }
    }
}