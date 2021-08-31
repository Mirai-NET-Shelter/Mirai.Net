using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using CommandLine;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    internal static class Program
    {
        private static async Task Main()
        {
            //bench marking
            var counter = new Stopwatch();
            counter.Start();

            var url = "https://httpbin.org/post";
            var json = new
            {
                Test = "TestValue",
                Test2 = false
            }.ToJsonString();
            
            var bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 2672886221,
                VerifyKey = "1145141919810",
                HttpSessionKey = "TEST KEY"
            };

            var result1 = await bot.PostHttp(url, json, true);

            
            
            counter.Stop();

            Console.WriteLine($"Build-in post: {counter.ElapsedMilliseconds}");

            counter.Reset();
            counter.Start();
            var client = new HttpClient();
            var content = new StringContent(json);

            var result2 = await (await client.PostAsync(url, content)).Content.ReadAsStringAsync();

            
            counter.Stop();

            Console.WriteLine($"Native HttpClient post: {counter.ElapsedMilliseconds}");
            // var signal = new ManualResetEvent(false);
            //
            // var bot = new MiraiBot
            // {
            //     Address = "localhost:8080",
            //     VerifyKey = "1145141919810",
            //     QQ = 2672886221
            // };
            //
            // await bot.Launch();
            //
            // await bot.GetManager<MessageManager>().SendGroupMessage("110838222", "Hello, World!".Append());
            //
            // //message listener bench mark
            //
            // var modules = CommandUtilities.LoadCommandModules("Mirai.Net.Test");
            // bot.MessageReceived
            //     .WhereAndCast<GroupMessageReceiver>()
            //     .Subscribe(x =>
            //     {
            //         x.ExecuteCommands(modules);
            //     });
            //
            // signal.WaitOne(TimeSpan.FromMinutes(1));
        }
    }
}