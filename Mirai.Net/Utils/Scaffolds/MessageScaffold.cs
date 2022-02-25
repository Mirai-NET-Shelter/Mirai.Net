using System.Collections.Generic;
using Mirai.Net.Data.Messages;

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
}