using System;
using System.Collections.Generic;
using System.Linq;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Utils.Scaffolds;

/// <summary>
///     消息相关的脚手架
/// </summary>
public static class MessageScaffold
{
    #region Legacy

    public static MessageChain Append(this string origin, params MessageBase[] append)
    {
        var re = new MessageChain { new PlainMessage(origin) };
        re.AddRange(append);

        return re;
    }
    
    public static MessageChain Append(this string origin, IEnumerable<MessageBase> append)
    {
        var re = new MessageChain { new PlainMessage(origin) };
        re.AddRange(append);

        return re;
    }

    public static MessageChain Append(this string origin, string append)
    {
        var re = new MessageChain { new PlainMessage(origin), new PlainMessage(append) };

        return re;
    }

    public static MessageChain Append(this MessageBase messageBase, params MessageBase[] append)
    {
        var re = new MessageChain { messageBase };
        re.AddRange(append);

        return re;
    }
    
    public static MessageChain Append(this MessageBase messageBase, IEnumerable<MessageBase> append)
    {
        var re = new MessageChain { messageBase };
        re.AddRange(append);

        return re;
    }

    public static MessageChain Append(this MessageBase messageBase, string append)
    {
        var re = new MessageChain { messageBase, new PlainMessage(append) };

        return re;
    }

    public static MessageChain Append(this IEnumerable<MessageBase> bases, params MessageBase[] append)
    {
        var re = bases.ToList();
        re.AddRange(append);

        return re.ToMessageChain();
    }

    public static MessageChain Append(this IEnumerable<MessageBase> bases, string append)
    {
        var re = bases.ToList();
        re.Add(new PlainMessage(append));

        return re.ToMessageChain();
    }
    
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

    public static MessageChain ToMessageChain(this MiraiCodeMessage miraiCodeMessage)
    {
        var chain = new MessageChain();
        var temp = new List<string>();
        
        var miraiCodeSuffixes = new[]
            { "image", "at", "atall", "flash", "face", "poke", "vipface", "app", "dice", "musicshare", "file" };
        var code = miraiCodeMessage.Code;

        var temkp = code.Split(miraiCodeSuffixes, StringSplitOptions.None);
        Console.WriteLine(temkp);
        //todo accomplish this
        return chain;
    }
}