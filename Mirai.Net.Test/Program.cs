using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Flurl;
using Mirai.Net.Data.Commands;
using Mirai.Net.Data.Events.Concretes.Message;
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
            // var exit = new ManualResetEvent(false);
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
            // bot.MessageReceived
            //     .OfType<GroupMessageReceiver>()
            //     .Subscribe(async r =>
            //     {
            //         if (r.MessageChain.Contains("/me", out MessageBase _))
            //         {
            //             var profile = await r.Sender.GetMemberProfileAsync();
            //             
            //             await r.SendMessageAsync($"Nick of acc: {profile.NickName}\r\nNick of group: {r.Sender.Name}");
            //         }
            //     });
            //
            // exit.WaitOne();

            var my = "/test -arg1 awkdj awd awd awd -arg2 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4".CanExecute<TestCommand>();

            Console.WriteLine(my);
        }
    }

    [CommandEntity(Name = "test")]
    class TestCommand
    {
        [CommandArgument(Name = "arg1")]
        public string Arg1 { get; set; }

        [CommandArgument(Name = "arg2", Default = 114514)]
        public int Arg2 { get; set; }

        [CommandArgument(Name = "arg3")]
        public string[] Arg3 { get; set; }

        [CommandArgument(Name = "arg4")]
        public bool Arg4 { get; set; }
    }
}