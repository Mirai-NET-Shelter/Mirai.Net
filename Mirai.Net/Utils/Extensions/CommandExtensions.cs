using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;

namespace Mirai.Net.Utils.Extensions
{
    public static class CommandExtensions
    {
        /// <summary>
        /// 根据传进来的文本判断是不是可以执行的命令
        /// </summary>
        /// <param name="module"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool CanExecute(this IModule module, string s)
        {
            var method = module.GetType().GetMethod(nameof(module.Execute));
            var trigger = method!.GetCustomAttribute<CommandTriggerAttribute>();

            if (trigger == null) throw new Exception("没有添加Trigger Attribute");
                            
            var command = $"{trigger.Prefix}{trigger.Name}";
            var predicate = new Predicate<string>(s => s.Contains(command));

            if (trigger.EqualName) predicate = s => s == command;

            return s.Split(' ').Any(predicate.Invoke);
        }

        /// <summary>
        /// 执行集合内的全部命令模块，除非它没开启
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="modules"></param>
        /// <param name="bot"></param>
        public static void ExecuteCommands(this MessageReceiverBase receiver, IEnumerable<IModule> modules)
        {
            foreach (var message in receiver.MessageChain)
            {
                foreach (var module in modules.Where(x => x.IsEnable is not false))
                {
                    if (message is PlainMessage plainMessage)
                    {
                        if (module.CanExecute(plainMessage.Text))
                        {
                            module.Execute(receiver, message);
                        }
                    }
                    else
                    {
                        if (module.CanExecute(message.ToJsonString()))
                        {
                            module.Execute(receiver, message);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 排除没有开启的模块
        /// </summary>
        /// <param name="modules"></param>
        /// <returns></returns>
        public static IEnumerable<IModule> ExcludeDisabledModules(this IEnumerable<IModule> modules)
        {
            foreach (var module in modules)
            {
                if (module.IsEnable is not false)
                {
                    yield return module;
                }
            }
        }

        /// <summary>
        /// 解析命令，Dictionary的key为参数名，value为参数值
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static IDictionary<string, string[]> ParseCommand(this CommandTriggerAttribute trigger, string s)
        {
            var split = s
                .Empty($"{trigger.Prefix}{trigger.Name}")
                .Trim()
                .Split(' ')
                .Where(x => x.IsNotNullOrEmpty())
                .ToList();

            var re = new Dictionary<string, string[]>();
            var indexes = new List<int>();

            split
                .Where(x => x.StartsWith(trigger.ArgsSeparator))
                .ToList()
                .ForEach(x => indexes.Add(split.IndexOf(x)));

            foreach (var index in indexes)
            {
                int next;
                if (indexes.IndexOf(index) + 1 >= indexes.Count)
                    next = split.Count - 1;
                else
                    next = indexes[indexes.IndexOf(index) + 1];

                var range = next != split.Count - 1
                    ? split.GetRange(index, next - index)
                    : split.GetRange(index, split.Count - index);

                re.Add(range.First(), range.GetRange(1, range.Count - 1).ToArray());
            }

            return re;
        }

        /// <summary>
        /// 获取当前的命令激发器(CommandTrigger)
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static CommandTriggerAttribute GetTrigger(this IModule module)
        {
            var method = module.GetType().GetMethod(nameof(module.Execute));
            return method!.GetCustomAttribute<CommandTriggerAttribute>();
        }

        /// <summary>
        /// 解析命令
        /// </summary>
        /// <param name="module"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static IDictionary<string, string[]> ParseCommand(this IModule module, string command)
        {
            return module.GetTrigger().ParseCommand(command);
        }
    }
}