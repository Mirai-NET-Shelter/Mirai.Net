using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mirai.Net.Data.Contact;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Data.Message.Concrete;
using Mirai.Net.Listeners;
using Mirai.Net.Managers;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Test
{
    /*
     * 用于测试Mirai.Net主项目的各项功能是否能够正常运转
     */
    static class Program
    {
        public static async Task Main()
        {
            #region Bot definition
            
            using var bot = new MiraiBot
            {
                Address = "127.0.0.1:8080",
                QQ = "2672886221",
                VerifyKey = "1145141919810",
                MessageListeners = new List<IMessageListener>
                {
                    new TestListener()
                },
                EventListeners = new List<IEventListener>
                {
                    new TestListenerEvent()
                }
            };
            
            await bot.Launch();
            
            #endregion

            var group = "809830266";
            var msg = new MessageManager(bot);
            var mgr = new GroupManager(bot, group);
            var cgr = new ContactManager(bot);

            await msg.SendGroupMessage(group, new PlainMessage
            {
                Text = "现在，我将随机挑选一位幸运群员赠送一份禁言套餐!"
            });

            var list = (await cgr.GetGroupMemberList(group))
                .Where(x => x.Permission == GroupPermission.Member)
                .ToList();

            var random = new Random();

            var member = list[random.Next(list.Count)];

            await msg.SendGroupMessage(group, new PlainMessage
            {
                Text = $"那么，这位幸运儿就是: "
            }, new AtMessage
            {
                Target = member.Name
            });

            await mgr.Mute(member.Id, TimeSpan.FromDays(30));

            await Task.Delay(TimeSpan.FromMinutes(1));

            await msg.SendGroupMessage(group, new PlainMessage
            {
                Text = $"当然啦，是开玩笑的!"
            });
            
            await mgr.UnMute(member.Id);

            #region Post handler
            
            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    return;
                }
            }
            
            #endregion
        }
    }
}