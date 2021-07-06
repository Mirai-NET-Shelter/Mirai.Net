using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;
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

            var lis = new TestListener();
            var bot = new MiraiBot
            {
                Address = "127.0.0.1:8080",
                QQ = "2672886221",
                VerifyKey = "1145141919810",
                MessageListeners = new List<IMessageListener>
                {
                    lis
                },
                EventListeners = new List<IEventListener>
                {
                    lis
                }
            };
            
            await bot.Launch();
            
            #endregion

            var manager = new ContactManager(bot);

            Console.WriteLine((await manager.GetBotProfile()).ToJsonString());
            
            foreach (var item in await manager.GetGroupMemberList("858594947"))
            {
                Console.WriteLine((await manager.GetGroupMemberProfile(item)).ToJsonString());
            }

            #region Post handler

            while (Console.ReadLine() == "exit")
            {
                return;
            }

            #endregion
        }
    }
}