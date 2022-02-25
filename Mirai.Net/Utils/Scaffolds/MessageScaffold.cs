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
    /// 转义成合法的mirai码
    /// </summary>
    /// <returns></returns>
    public static string EscapeMiraiCode(this string origin)
    {
        var rawArgs = origin
            .GetMiraiCodeArguments();

        var result = rawArgs
            .Replace("[", @"\[")
            .Replace("]", @"\]")
            .Replace(":", @"\:")
            .Replace(",", @"\,")
            .Replace("\\", @"\\");
        
        return origin.Replace(rawArgs, result);
    }

    private static string GetMiraiCodeArguments(this string origin)
    {
        var miraiCodeSuffixes = new[]
            { "image", "at", "atall", "flash", "face", "poke", "vipface", "app", "dice", "musicshare", "file" };

        var miraiCodes = miraiCodeSuffixes.Select(m => $"mirai:{m}").ToList();
        //todo: accomplish this
        return miraiCodes.First();
    }

    /// <summary>
    /// 判断一个mirai码有没有参数
    /// </summary>
    /// <param name="miraiCode"></param>
    /// <returns></returns>
    public static bool HasArguments(this MiraiCodeMessage miraiCode)
    {
        return miraiCode.Code.Count(c => c == ':') > 1;
    }
}