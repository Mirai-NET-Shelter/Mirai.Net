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
}