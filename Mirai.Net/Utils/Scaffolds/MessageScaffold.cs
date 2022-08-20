using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;

namespace Mirai.Net.Utils.Scaffolds;

/// <summary>
///     消息相关的脚手架
/// </summary>
public static class MessageScaffold
{
    #region Legacy

    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this string origin, params MessageBase[] append)
    {
        var re = new MessageChain { new PlainMessage(origin) };
        re.AddRange(append);

        return re;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this string origin, IEnumerable<MessageBase> append)
    {
        var re = new MessageChain { new PlainMessage(origin) };
        re.AddRange(append);

        return re;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this string origin, string append)
    {
        var re = new MessageChain { new PlainMessage(origin), new PlainMessage(append) };

        return re;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageBase"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this MessageBase messageBase, params MessageBase[] append)
    {
        var re = new MessageChain { messageBase };
        re.AddRange(append);

        return re;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageBase"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this MessageBase messageBase, IEnumerable<MessageBase> append)
    {
        var re = new MessageChain { messageBase };
        re.AddRange(append);

        return re;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageBase"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this MessageBase messageBase, string append)
    {
        var re = new MessageChain { messageBase, new PlainMessage(append) };

        return re;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bases"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this IEnumerable<MessageBase> bases, params MessageBase[] append)
    {
        var re = bases.ToList();
        re.AddRange(append);

        return re.ToMessageChain();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="bases"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this IEnumerable<MessageBase> bases, string append)
    {
        var re = bases.ToList();
        re.Add(new PlainMessage(append));

        return re.ToMessageChain();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bases"></param>
    /// <param name="append"></param>
    /// <returns></returns>
    public static MessageChain Append(this IEnumerable<MessageBase> bases, IEnumerable<MessageBase> append)
    {
        var re = bases.ToList();
        re.AddRange(append);

        return re.ToMessageChain();
    }

    #endregion
    
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
    /// <param name="duration"></param>
    [Obsolete("此方法在mirai-api-http 2.6.0及以上版本会导致异常")]
    public static async Task RecallAfter(this Task<string> messageIdTask, TimeSpan duration)
    {
        var messageId = await messageIdTask;
        DispatchUtils.ExecuteScheduledActionAsync(duration, async () =>
        {
            await MessageManager.RecallAsync(messageId);
        });
    }

    /// <summary>
    /// 在指定的时间之后撤回消息
    /// </summary>
    /// <param name="messageIdTask"></param>
    /// <param name="milliseconds"></param>
    [Obsolete("此方法在mirai-api-http 2.6.0及以上版本会导致异常")]
    public static async Task RecallAfter(this Task<string> messageIdTask, int milliseconds)
    {
        await messageIdTask.RecallAfter(TimeSpan.FromMilliseconds(milliseconds));
    }

    /// <summary>
    /// 在指定的时间之后撤回消息
    /// </summary>
    /// <param name="messageIdAndTargetTask">返回消息id,好友id或群id的Task</param>
    /// <param name="duration"></param>
    public static async Task RecallAfter(this Task<KeyValuePair<string, string>> messageIdAndTargetTask, TimeSpan duration)
    {
        var result = await messageIdAndTargetTask;
        var messageId = result.Key;
        var target = result.Value;
        DispatchUtils.ExecuteScheduledActionAsync(duration, async () =>
        {
            await MessageManager.RecallAsync(messageId, target);
        });
    }

    /// <summary>
    /// 在指定的时间之后撤回消息
    /// </summary>
    /// <param name="messageIdAndTargetTask">返回消息id,好友id或群id的Task</param>
    /// <param name="milliseconds"></param>
    public static async Task RecallAfter(this Task<KeyValuePair<string, string>> messageIdAndTargetTask, int milliseconds)
    {
        await messageIdAndTargetTask.RecallAfter(TimeSpan.FromMilliseconds(milliseconds));
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