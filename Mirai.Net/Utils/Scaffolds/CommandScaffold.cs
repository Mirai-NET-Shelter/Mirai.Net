using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Commands;
using Mirai.Net.Data.Exceptions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;

namespace Mirai.Net.Utils.Scaffolds;

public static class CommandScaffold
{
    /// <summary>
    /// 解析命令到实体类
    /// </summary>
    /// <param name="origin"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="InvalidCommandException"></exception>
    /// <exception cref="InvalidCommandEntityException"></exception>
    public static T ParseCommand<T>(this string origin) where T : class, new()
    {
        origin = origin.Trim();
        
        var re = new T();
        var type = re.GetType();
        var commandInfo = type.GetCustomAttribute<CommandEntityAttribute>();

        #region Pre check

        if (!HasValidIdentifier(commandInfo, origin))
            throw new InvalidCommandException($"此字符串无法解析为命令:\r\n{origin}");

        #endregion
        
        var properties = type.GetProperties();
        var args = properties
            .Select(x => (x, x.GetCustomAttribute<CommandArgumentAttribute>()))
            .Where(x => x.Item2 != null)
            .ToList();
        
        foreach (var (propertyInfo, argumentInfo) in args)
        {
            var argumentSyntax = $"{commandInfo.Separator}{argumentInfo.Name}";
            var argumentMeta = $"{argumentInfo.Name}/{propertyInfo.Name}";
            
            var propertyType = propertyInfo.PropertyType;

            if (origin.Split(' ').Count(x => x == argumentSyntax) > 1)
                throw new InvalidCommandException($"命令参数{argumentInfo.Name}重复");

            switch (argumentInfo.IsRequired)
            {
                case true when argumentInfo.Default is not null:
                    throw new InvalidCommandEntityException(
                        $"命令实体不能同时设置为必须参数和默认值: {argumentMeta}");
                case true when !origin.Contains(argumentSyntax):
                    throw new InvalidCommandException($"缺失必要参数: {argumentMeta}");
                case true when propertyInfo.PropertyType == typeof(bool):
                    throw new InvalidCommandException($"选项参数{argumentMeta}不可以是必须参数");
                case false when argumentInfo.Default is not null:
                    propertyInfo.SetValue(re, argumentInfo.Default);
                    break;
            }

            switch (origin.Contains(argumentSyntax))
            {
                case true when propertyType == typeof(bool):
                    propertyInfo.SetValue(re, true);
                    break;
                case true when propertyType == typeof(IEnumerable<string>) || 
                               propertyType == typeof(List<string>) || 
                               propertyType == typeof(string[]):
                    
                    var arg = GetMiddleContent(commandInfo, origin, argumentSyntax)
                        .Split(' ')
                        .Where(x => x.IsNotNullOrEmpty()).ToList();
                    
                    arg.RemoveAt(0);

                    if (propertyType == typeof(string[]))
                    {
                        propertyInfo.SetValue(re, arg.ToArray());
                        break;
                    }
                    propertyInfo.SetValue(re, arg);
                    break;
                case true when propertyType == typeof(string):
                    propertyInfo.SetValue(re, GetMiddleContent(commandInfo, origin, argumentSyntax));
                    break;
                case true when propertyType == typeof(int) || 
                               propertyType == typeof(long):
                    var intArg = GetMiddleContent(commandInfo, origin, argumentSyntax)
                        .IsIntegerOrThrow(new InvalidCommandException($"参数{argumentMeta}必须为整数"));

                    Console.WriteLine(propertyType == typeof(int));
                    if (int.TryParse(intArg, out var outInt))
                    {
                        propertyInfo.SetValue(re, outInt);
                        break;
                    }
                    
                    if (long.TryParse(intArg, out var outLong))
                        propertyInfo.SetValue(re, outLong);
                    
                    break;
                case true when propertyType == typeof(double):
                    var doubleArg = GetMiddleContent(commandInfo, origin, argumentSyntax);

                    if (!double.TryParse(doubleArg, out var d))
                        throw new InvalidCommandException($"参数{argumentMeta}必须为双精度浮点数");

                    propertyInfo.SetValue(re, d);
                    break;
            }
        }

        return re;
    }

    public static bool CanExecute<T>(this string origin) where T : class, new()
    {
        var entity = new T();
        var type = entity.GetType();
        var properties = type.GetProperties();
        var commandInfo = type.GetCustomAttribute<CommandEntityAttribute>();

        if (!HasValidIdentifier(commandInfo, origin))
            return false;
        
        var args = properties
            .Select(x => (x, x.GetCustomAttribute<CommandArgumentAttribute>()))
            .Where(x => x.Item2 != null)
            .ToList();
        
        foreach (var (propertyInfo, argumentInfo) in args)
        {
            var argumentSyntax = $"{commandInfo.Separator}{argumentInfo.Name}";

            var propertyType = propertyInfo.PropertyType;

            if (origin.Split(' ').Count(x => x == argumentSyntax) > 1)
                return false;
            
            switch (argumentInfo.IsRequired)
            {
                case true when argumentInfo.Default is not null:
                    return false;
                case true when !origin.Contains(argumentSyntax):
                    return false;
                case true when propertyInfo.PropertyType == typeof(bool):
                    return false;
            }
            
            switch (origin.Contains(argumentSyntax))
            {
                case true when propertyType == typeof(int) || 
                               propertyType == typeof(long):
                    var intArg = GetMiddleContent(commandInfo, origin, argumentSyntax);

                    if (intArg.IsNotInteger())
                        return false;

                    return int.TryParse(intArg, out _) || long.TryParse(intArg, out _);
                case true when propertyType == typeof(double):
                    var doubleArg = GetMiddleContent(commandInfo, origin, argumentSyntax);
                    
                    return double.TryParse(doubleArg, out _);
            }
        }

        return true;
    }

    /// <summary>
    /// 判断某命令的起始符是否合法
    /// </summary>
    /// <param name="commandInfo"></param>
    /// <param name="origin"></param>
    /// <returns></returns>
    private static bool HasValidIdentifier(CommandEntityAttribute commandInfo, string origin)
    {
        var syntax = commandInfo.Alias
            .Aggregate($"{commandInfo.Identifier}{commandInfo.Name}", (a, b) => $"{a};{commandInfo.Identifier}{b}")
            .Split(';');

        return syntax.Any(s =>
        {
            var index = origin.IndexOf(commandInfo.Separator, 1, StringComparison.Ordinal);

            if (index == -1)
                return origin.Trim() == s;

            return origin.Substring(0, index).Trim() == s;
        });
    }
    
    /// <summary>
    /// 获取两个参数之间的内容
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="origin"></param>
    /// <param name="syntax"></param>
    /// <returns></returns>
    private static string GetMiddleContent(CommandEntityAttribute entity, string origin, string syntax)
    {
        var left = origin.IndexOf(syntax, StringComparison.Ordinal);
        var right = origin.IndexOf(entity.Separator, left + 1, StringComparison.Ordinal);
        var rawArg = right != -1 ? origin.Substring(left, right - left) : origin.Substring(left);

        rawArg = rawArg.Empty(syntax).Trim();
        return rawArg;
    }
    
    /// <summary>
    ///     消息链是否可以执行命令
    /// </summary>
    /// <param name="originalChain"></param>
    /// <param name="trigger"></param>
    /// <returns></returns>
    [Obsolete]
    public static bool CanExecute(this IEnumerable<MessageBase> originalChain, CommandTriggerAttribute trigger)
    {
        return CanExecute(originalChain, trigger, out _);
    }

    /// <summary>
    ///     消息链是否可以执行命令
    /// </summary>
    /// <param name="originalChain"></param>
    /// <param name="trigger"></param>
    /// <param name="executedBy">哪个消息是可以执行的</param>
    /// <returns></returns>
    [Obsolete]
    public static bool CanExecute(this IEnumerable<MessageBase> originalChain, CommandTriggerAttribute trigger,
        out MessageBase executedBy)
    {
        var chain = originalChain.ToList();
        if (chain.Any(x => x.Type == Messages.Plain))
            foreach (var message in chain.OfType<PlainMessage>())
                if (trigger.IsCommand(message.Text))
                {
                    executedBy = message;
                    return true;
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
    ///     判断一个字符串是否为命令
    /// </summary>
    /// <param name="trigger"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    [Obsolete]
    public static bool IsCommand(this CommandTriggerAttribute trigger, string s)
    {
        var expectation = $"{trigger.Prefix}{trigger.Name}";

        return trigger.EqualName ? s.StartsWith(expectation) : s.Contains(expectation);
    }

    /// <summary>
    ///     解析命令，Dictionary的key为参数名，value为参数值
    /// </summary>
    /// <param name="trigger"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    [Obsolete]
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
    ///     解析命令
    /// </summary>
    /// <param name="commandModule"></param>
    /// <param name="command"></param>
    /// <returns></returns>
    [Obsolete]
    public static IDictionary<string, string[]> ParseCommand(this ICommandModule commandModule, string command)
    {
        return commandModule.GetCommandTrigger().ParseCommand(command);
    }

    /// <summary>
    ///     检查某命令是否有参数
    /// </summary>
    /// <param name="trigger"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    [Obsolete]
    public static bool HasParameters(this CommandTriggerAttribute trigger, string s)
    {
        return trigger.ParseCommand(s).Count != 0;
    }

    /// <summary>
    ///     获取本模块的CommandTrigger
    /// </summary>
    /// <param name="commandModule"></param>
    /// <returns></returns>
    [Obsolete]
    public static CommandTriggerAttribute GetCommandTrigger(this ICommandModule commandModule)
    {
        return commandModule.GetType().GetMethod(nameof(commandModule.Execute))!
            .GetCustomAttribute<CommandTriggerAttribute>();
    }

    /// <summary>
    ///     执行集合内的全部命令模块，除非它没开启
    /// </summary>
    /// <param name="receiver"></param>
    /// <param name="modules"></param>
    [Obsolete]
    public static void ExecuteCommandModules(this MessageReceiverBase receiver, IEnumerable<ICommandModule> modules)
    {
        foreach (var module in modules.Where(x => x.IsEnable is not false))
            if (receiver.MessageChain.CanExecute(module.GetCommandTrigger(), out var message))
                module.Execute(receiver, message);
    }

    /// <summary>
    ///     加载指定命名空间的命令模块
    /// </summary>
    [Obsolete]
    public static IEnumerable<ICommandModule> LoadCommandModules(string space)
    {
        var assembly = Assembly.GetEntryAssembly();
        var types = assembly.GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && !x.IsInterface)
            .Where(x => x.GetInterfaces().Any(x => x == typeof(ICommandModule)))
            .Where(x => x!.FullName!.Contains(space))
            .ToList();

        foreach (var type in types) yield return Activator.CreateInstance(type) as ICommandModule;
    }

    /// <summary>
    ///     加载与某模块同命名空间的所有模块
    /// </summary>
    /// <typeparam name="T">某模块</typeparam>
    /// <returns></returns>
    [Obsolete]
    public static IEnumerable<ICommandModule> LoadCommandModules<T>() where T : ICommandModule
    {
        var basic = typeof(T);

        var types = Assembly.GetAssembly(basic).GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && !x.IsInterface)
            .Where(x => x.GetInterfaces().Any(x => x == typeof(ICommandModule)))
            .Where(x => x!.FullName!.Contains(basic.Namespace!))
            .ToList();

        foreach (var type in types) yield return Activator.CreateInstance(type) as ICommandModule;
    }
}