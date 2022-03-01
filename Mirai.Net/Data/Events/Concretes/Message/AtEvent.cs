using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Shared;

namespace Mirai.Net.Data.Events.Concretes.Message;

public class AtEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.At;

    public GroupMessageReceiver Receiver { get; set; }
}