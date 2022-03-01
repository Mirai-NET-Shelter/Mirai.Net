using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Shared;

namespace Mirai.Net.Data.Events.Concretes.Message;

/// <summary>
/// Bot被人at
/// </summary>
public class AtEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.At;

    /// <summary>
    /// 被at的那条消息容器
    /// </summary>
    public GroupMessageReceiver Receiver { get; set; }
}