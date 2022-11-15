using Mirai.Net.Data.Messages;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mirai.Net.Utils.Scaffolds;

/// <summary>
///     消息相关的脚手架
/// </summary>
public static class MessageScaffold
{
    /// <summary>
    /// 把枚举接口转换为高层MessageChain对象
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static MessageChain ToMessageChain<TSource>(this IEnumerable<TSource> source) where TSource : MessageBase
    {
        return new MessageChain(source);
    }

    /// <summary>
    /// 把单个消息对象转换成MessageChain对象
    /// </summary>
    /// <param name="origin"></param>
    /// <typeparam name="TSource"></typeparam>
    /// <returns></returns>
    public static MessageChain ToMessageChain<TSource>(this TSource origin) where TSource : MessageBase
    {
        return new MessageChain { origin };
    }

    /// <summary>
    /// 转义成兼容mirai码的文本
    /// </summary>
    /// <returns></returns>
    public static string EscapeMiraiCode(this string origin)
    {
        var result = origin
            .Replace("[", @"\[")
            .Replace("]", @"\]")
            .Replace(":", @"\:")
            .Replace(",", @"\,")
            .Replace("\\", @"\\");

        return result;
    }

    /// <summary>
    /// 在指定的时间之后撤回消息
    /// </summary>
    /// <param name="messageIdTask"></param>
    /// <param name="target">好友id或群id</param>
    /// <param name="duration"></param>
    public static async Task RecallAfter(this Task<string> messageIdTask, string target, TimeSpan duration)
    {
        var messageId = await messageIdTask;
        DispatchUtils.ExecuteScheduledActionAsync(duration, async () =>
        {
            await MessageManager.RecallAsync(messageId, target);
        });
    }

    /// <summary>
    /// 在指定的时间之后撤回消息
    /// </summary>
    /// <param name="messageIdTask"></param>
    /// <param name="target">好友id或群id</param>
    /// <param name="milliseconds"></param>
    public static async Task RecallAfter(this Task<string> messageIdTask, string target, int milliseconds)
    {
        await messageIdTask.RecallAfter(target, TimeSpan.FromMilliseconds(milliseconds));
    }

    /// <summary>
    /// 在指定时间之后发送消息，这是个同步方法
    /// </summary>
    /// <param name="messageTask"></param>
    /// <param name="duration"></param>
    public static void SendAfter(this Task<string> messageTask, TimeSpan duration)
    {
        DispatchUtils.ExecuteScheduledActionAsync(duration, async () =>
        {
            await messageTask;
        });
    }

    /// <summary>
    /// 在指定时间之后发送消息，这是个同步方法
    /// </summary>
    /// <param name="messageTask"></param>
    /// <param name="milliseconds"></param>
    public static void SendAfter(this Task<string> messageTask, int milliseconds)
    {
        messageTask.SendAfter(TimeSpan.FromMilliseconds(milliseconds));
    }
}