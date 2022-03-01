namespace Mirai.Net.Data.Events.Concretes.Request;

public class NewFriendRequestedEvent : RequestedEventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.NewFriendRequested;
}