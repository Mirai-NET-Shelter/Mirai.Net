using System.Collections.Generic;
using System.Linq;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;

namespace Mirai.Net.Utils.Scaffolds;

/// <summary>
///     消息相关的脚手架
/// </summary>
public static class MessageScaffold
{
    public static MessageBase[] Append(this string origin, params MessageBase[] append)
    {
        var re = new List<MessageBase> { new PlainMessage(origin) };
        re.AddRange(append);

        return re.ToArray();
    }
    
    public static MessageBase[] Append(this string origin, IEnumerable<MessageBase> append)
    {
        var re = new List<MessageBase> { new PlainMessage(origin) };
        re.AddRange(append);

        return re.ToArray();
    }

    public static MessageBase[] Append(this string origin, string append)
    {
        var re = new List<MessageBase> { new PlainMessage(origin), new PlainMessage(append) };

        return re.ToArray();
    }

    public static MessageBase[] Append(this MessageBase messageBase, params MessageBase[] append)
    {
        var re = new List<MessageBase> { messageBase };
        re.AddRange(append);

        return re.ToArray();
    }
    
    public static MessageBase[] Append(this MessageBase messageBase, IEnumerable<MessageBase> append)
    {
        var re = new List<MessageBase> { messageBase };
        re.AddRange(append);

        return re.ToArray();
    }

    public static MessageBase[] Append(this MessageBase messageBase, string append)
    {
        var re = new List<MessageBase> { messageBase, new PlainMessage(append) };

        return re.ToArray();
    }

    public static MessageBase[] Append(this IEnumerable<MessageBase> bases, params MessageBase[] append)
    {
        var re = bases.ToList();
        re.AddRange(append);

        return re.ToArray();
    }

    public static MessageBase[] Append(this IEnumerable<MessageBase> bases, string append)
    {
        var re = bases.ToList();
        re.Add(new PlainMessage(append));

        return re.ToArray();
    }
    
    public static MessageBase[] Append(this IEnumerable<MessageBase> bases, IEnumerable<MessageBase> append)
    {
        var re = bases.ToList();
        re.AddRange(append);

        return re.ToArray();
    }

    public static bool Contains(this IEnumerable<MessageBase> bases, string message)
    {
        return bases.Select(x => x.ToJsonString()).Any(x => x.Contains(message));
    }
    
    public static bool Contains(this IEnumerable<MessageBase> bases, string message, out MessageBase messageBase)
    {
        foreach (var @base in bases)
        {
            var json = @base.ToJsonString();
            if (json.Contains(message))
            {
                messageBase = @base;
                return true;
            }
        }

        messageBase = null;
        return false;
    }
    
    public static bool Contains(this IEnumerable<MessageBase> bases, string message, out IEnumerable<MessageBase> origin)
    {
        var messageBases = bases.ToList();
        foreach (var @base in messageBases)
        {
            var json = @base.ToJsonString();
            if (json.Contains(message))
            {
                origin = messageBases;
                return true;
            }
        }

        origin = null;
        return false;
    }

    public static string GetPlainMessage(this IEnumerable<MessageBase> messageChain)
    {
        return messageChain
            .OfType<PlainMessage>()
            .Select(x => x.Text)
            .Aggregate((s, s1) => s + s1);
    }
    
    public static IEnumerable<string> GetSeparatedPlainMessage(this IEnumerable<MessageBase> messageChain)
    {
        return messageChain
            .OfType<PlainMessage>()
            .Select(x => x.Text);
    }
}