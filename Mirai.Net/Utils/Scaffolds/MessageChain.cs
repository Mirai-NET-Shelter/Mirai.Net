using Manganese.Array;
using Manganese.Text;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Mirai.Net.Data.Messages;

/// <summary>
/// 消息链
/// </summary>
public partial class MessageChain : List<MessageBase>
{
    /// <summary>
    /// AddRange
    /// </summary>
    /// <param name="collection"></param>
    public MessageChain(IEnumerable<MessageBase> collection) : base(collection)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public MessageChain() : base()
    {
    }

    /// <summary>
    /// 运行时安全的Mirai码
    /// </summary>
    public string MiraiCode
    {
        get
        {
            System.Text.StringBuilder builder = new();

            this.ForEach(x => 
            {
                try
                {
                    builder.Append(x.SerializeToMiraiCode());
                }
                catch
                {}
            });

            return builder.ToString();
        }
    }

    /// <summary>
    /// 获取消息链中的纯文本消息
    /// </summary>
    /// <returns>如果没有文本消息返回空字符串</returns>
    public string GetPlainMessage()
    {
        var plain = this.OfType<PlainMessage>().ToList();
        if (!plain.Any())
            return string.Empty;

        return plain.Select(x => x.Text).JoinToString("");
    }

#nullable enable

    /// <summary>
    /// 获取该消息的消息来源 如果没有来源则返回null
    /// </summary>
    /// <returns></returns>
    public SourceMessage? GetSourceMessage() => this.OfType<SourceMessage>().FirstOrDefault();

    /// <summary>
    /// 获取该消息的消息来源 如果没有引用则返回null
    /// </summary>
    /// <returns></returns>
    public QuoteMessage? GetQuoteMessage() => this.OfType<QuoteMessage>().FirstOrDefault();

#nullable disable

    /// <summary>
    /// 获取消息链中的文本消息并且保持原有连贯性
    /// </summary>
    /// <returns>如果没有文本消息返回空列表</returns>
    public List<string> GetSeparatedPlainMessage()
    {
        var plain = this.OfType<PlainMessage>().ToList();
        if (!plain.Any())
            return new List<string>();

        return plain.Select(x => x.Text).ToList();
    }

    /// <summary>
    /// 将本消息链发送到指定接收器
    /// </summary>
    /// <param name="receiver"></param>
    /// <returns></returns>
    public async Task<string> SendToAsync(GroupMessageReceiver receiver)
    {
        return await receiver.SendMessageAsync(this);
    }

    /// <summary>
    /// 将本消息链发送到指定接收器
    /// </summary>
    /// <param name="receiver"></param>
    /// <returns></returns>
    public async Task<string> SendToAsync(FriendMessageReceiver receiver)
    {
        return await receiver.SendMessageAsync(this);
    }

    /// <summary>
    /// 将本消息链发送到指定接收器
    /// </summary>
    /// <param name="receiver"></param>
    /// <returns></returns>
    public async Task<string> SendToAsync(TempMessageReceiver receiver)
    {
        return await receiver.SendMessageAsync(this);
    }

    /// <summary>
    /// 将该消息链序列化为mirai码
    /// </summary>
    /// <returns></returns>
    public string SerializeToMiraiCode()
    {
        System.Text.StringBuilder builder = new();

        this.ForEach(x => builder.Append(x.SerializeToMiraiCode()));

        return builder.ToString();
    }

    /// <summary>
    /// 自动转换单个消息为消息链
    /// </summary>
    /// <param name="messageBase"></param>
    /// <returns></returns>
    public static implicit operator MessageChain(MessageBase messageBase)
    {
        return messageBase.ToMessageChain();
    }

    /// <summary>
    /// 转换string为单文本消息链
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static implicit operator MessageChain(string message)
    {
        return new PlainMessage(message).ToMessageChain();
    }

    /// <summary>
    /// 拼接两个消息链
    /// </summary>
    /// <param name="chain1"></param>
    /// <param name="chain2"></param>
    /// <returns></returns>
    public static MessageChain operator +(MessageChain chain1, MessageChain chain2)
    {
        var chain = new MessageChain();
        chain.AddRange(chain1);
        chain.AddRange(chain2);
        return chain;
    }

    /// <summary>
    /// 拼接消息链和消息
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static MessageChain operator +(MessageChain chain, MessageBase msg)
    {
        chain.Add(msg);
        return chain;
    }

    /// <summary>
    /// 返回两个消息链是否相等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator ==(MessageChain left, MessageChain right)
    {
        left = left.Where(x => x is not SourceMessage).ToMessageChain();

        right = right.Where(x => x is not SourceMessage).ToMessageChain();

        if (left.Count != right.Count) return false;

        for (int i = 0; i < left.Count; i++)
        {
            if (left[i].Type != right[i].Type) return false;

            if (left[i].Type == Messages.Source || right[i].Type == Messages.Source)
                continue;

            // 这段代码用了一种极其诡异的方法判断是否相等
            // 首先检查能否转换为图片消息然后挨个判断四个属性 都不相等就返回false 有一个相等就返回true
            // 然后看不能转换的时候利用record直接判左右相等
            // 最后把前面所有的一切套进if里顺便加反转 如果为true什么都不做 如果为false直接返回false
            if (!((left[i], right[i]) switch
            {
                (ImageMessage leftmsg, ImageMessage rightmsg) => (leftmsg.ImageId != rightmsg.ImageId && leftmsg.Url != rightmsg.Url && leftmsg.Path != rightmsg.Path && leftmsg.Base64 != rightmsg.Base64) ? false : true,

                (var leftmsg, var rightmsg) => leftmsg == rightmsg ? true : false
            })) return false;
        }

        // 如果还有代码没有直接返回false能走到这里那么估计完全相等了直接返回true
        return true;
    }

    /// <summary>
    /// 返回两个消息链是否不等
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    public static bool operator !=(MessageChain left, MessageChain right) => !(left == right);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public override bool Equals(object msg)
    {
        return (object)this == msg;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}