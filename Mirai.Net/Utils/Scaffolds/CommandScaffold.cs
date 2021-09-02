using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;

namespace Mirai.Net.Utils.Scaffolds
{
    public static class CommandScaffold
    {
        /// <summary>
        /// 消息链是否可以执行命令
        /// </summary>
        /// <param name="originalChain"></param>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public static bool CanExecute(this IEnumerable<MessageBase> originalChain, CommandTriggerAttribute trigger)
        {
            return CanExecute(originalChain, trigger, out _);
        }

        /// <summary>
        /// 消息链是否可以执行命令
        /// </summary>
        /// <param name="originalChain"></param>
        /// <param name="trigger"></param>
        /// <param name="executedBy">哪个消息是可以执行的</param>
        /// <returns></returns>
        public static bool CanExecute(this IEnumerable<MessageBase> originalChain, CommandTriggerAttribute trigger, out MessageBase executedBy)
        {
            var chain = originalChain.ToList();
            if (chain.Any(x => x.Type == Messages.Plain))
            {
                foreach (var message in chain.WhereAndCast<PlainMessage>())
                {
                    if (trigger.IsCommand(message.Text))
                    {
                        executedBy = message;
                        return true;
                    }
                }
            }

            trigger.EqualName = false;
            foreach (var s in chain.Where(s => trigger.IsCommand(s.ToJsonString())))
            {
                executedBy = s;
                return true;
            }

            executedBy = null;
            return false;
        }

        /// <summary>
        /// 判断一个字符串是否为命令
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsCommand(this CommandTriggerAttribute trigger, string s)
        {
            var expectation = $"{trigger.Prefix}{trigger.Name}";

            return trigger.EqualName ? s.StartsWith(expectation) : s.Contains(expectation);
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
                .Trim().Split(' ')
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

                re.Add(range.First().TrimStart(trigger.ArgsSeparator.ToCharArray()),
                    range.GetRange(1, range.Count - 1).ToArray());
            }

            return re;
        }
        
        /// <summary>
        /// 解析命令
        /// </summary>
        /// <param name="commandModule"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        public static IDictionary<string, string[]> ParseCommand(this ICommandModule commandModule, string command)
        {
            return commandModule.GetCommandTrigger().ParseCommand(command);
        }

        /// <summary>
        /// 检查某命令是否有参数
        /// </summary>
        /// <param name="trigger"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool HasParameters(this CommandTriggerAttribute trigger, string s)
        {
            return trigger.ParseCommand(s).Count != 0;
        }

        /// <summary>
        /// 获取本模块的CommandTrigger
        /// </summary>
        /// <param name="commandModule"></param>
        /// <returns></returns>
        public static CommandTriggerAttribute GetCommandTrigger(this ICommandModule commandModule)
        {
            return commandModule.GetType().GetMethod(nameof(commandModule.Execute))!.GetCustomAttribute<CommandTriggerAttribute>();
        }
        
        /// <summary>
        /// 执行集合内的全部命令模块，除非它没开启
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="modules"></param>
        /// <param name="bot"></param>
        public static void ExecuteCommandModules(this MessageReceiverBase receiver, IEnumerable<ICommandModule> modules)
        {
            foreach (var module in modules.Where(x => x.IsEnable is not false))
            {
                if (receiver.MessageChain.CanExecute(module.GetCommandTrigger(), out var message))
                {
                    module.Execute(receiver, message);
                }
            }
        }
        
        /// <summary>
        /// 加载指定命名空间的命令模块
        /// </summary>
        public static IEnumerable<ICommandModule> LoadCommandModules(string space)
        {
            var assembly = Assembly.GetEntryAssembly();
            var types = assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && !x.IsInterface)
                .Where(x => x.GetInterfaces().Any(x => x == typeof(ICommandModule)))
                .Where(x => x!.FullName!.Contains(space))
                .ToList();

            foreach (var type in types)
            {
                yield return Activator.CreateInstance(type) as ICommandModule;
            }
        }

        /// <summary>
        /// 加载与某模块同命名空间的所有模块
        /// </summary>
        /// <typeparam name="T">某模块</typeparam>
        /// <returns></returns>
        public static IEnumerable<ICommandModule> LoadCommandModules<T>() where T : ICommandModule
        {
            var basic = typeof(T);
            
            var types = Assembly.GetAssembly(basic).GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && !x.IsInterface)
                .Where(x => x.GetInterfaces().Any(x => x == typeof(ICommandModule)))
                .Where(x => x!.FullName!.Contains(basic.Namespace!))
                .ToList();
            
            foreach (var type in types)
            {
                yield return Activator.CreateInstance(type) as ICommandModule;
            }
        }
    }
}