using System;
using System.Diagnostics;
using System.Linq;
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
            var exit = new ManualResetEvent(false);

            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                VerifyKey = "1145141919810",
                QQ = "2672886221"
            };
            
            await bot.LaunchAsync();

            bot.MessageReceived
                .WhereAndCast<GroupMessageReceiver>()
                .Subscribe(async x =>
                {
                    if (x.MessageChain.WhereAndCast<PlainMessage>().Any(p => p.Text.Contains("/rmember")))
                    {
                        var members = (await AccountManager.GetGroupMembersAsync(x.Sender.Group.Id))
                            .Where(member => member.Permission == Permissions.Member)
                            .ToList();
                        var random = new Random();

                        var luckyDog = members[random.Next(members.Count)];

                        var randomMember = await GroupManager.GetMemberAsync(luckyDog.Id, luckyDog.Group.Id);

                        await x.SendGroupMessageAsync(randomMember.ToJsonString());
                    }
                });

            await GroupManager.MuteAsync("1472398496", "110838222", TimeSpan.FromHours(1));

            exit.WaitOne();
        }
    }
}