using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Listeners;
using Mirai.Net.Listeners.Concretes;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Test
{
    /*
     * 这是一个基于.Net5的控制台应用程序，用于测试Mirai.Net主项目的各项功能是否能够正常运转
     */
    class Program
    {
        static async Task Main(string[] args)
        {
            var bot = new MiraiBot
            {
                Address = "127.0.0.1:8080",
                QQ = "2672886221",
                VerifyKey = "1145141919810",
                EventListeners = new List<IEventListener>
                {
                    new TestListener()
                }
            };
            
            await bot.Launch();
        }
    }
}