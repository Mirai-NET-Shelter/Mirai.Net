/*
 * 这是直接引用Mirai.Net源代码的实战项目
 */

using System;
using System.Reactive.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Helium.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Helium
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 2672886221,
                VerifyKey = "1145141919810"
            };

            await bot.Launch();

            var modules = new ICommandModule[]
            {
                new TestModule()
            };
            
            //传播订阅到模块
            bot.MessageReceived
                .WhereAndCast<GroupMessageReceiver>()
                .Subscribe(x =>
                {
                    foreach (var message in x.MessageChain.WhereAndCast<PlainMessage>())
                    {
                        foreach (var module in modules)
                        {
                            var method = module.GetType().GetMethod(nameof(module.Execute));
                            var trigger = method!.GetCustomAttribute<CommandTriggerAttribute>();

                            if (trigger == null) continue;
                            
                            var command = $"{trigger.Prefix}{trigger.Name}";
                            var predicate = new Predicate<string>(s => s.Contains(command));

                            if (trigger.EqualName) predicate = s => s == command;

                            foreach (var s in message.Text.Split(" "))
                            {
                                if (predicate.Invoke(s))
                                {
                                    module.Execute(bot, x, message);
                                }
                            }
                        }
                    }
                });

            while (true)
            {
                if (Console.ReadLine() == "exit")
                {
                    return;
                }
            }
        }
    }
}