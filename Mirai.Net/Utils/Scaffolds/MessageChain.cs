using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Manganese.Text;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;

// ReSharper disable once CheckNamespace
namespace Mirai.Net.Data.Messages;

public partial class MessageChain : List<MessageBase>
{
    public MessageChain(IEnumerable<MessageBase> collection) : base(collection)
    {
    }

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
}