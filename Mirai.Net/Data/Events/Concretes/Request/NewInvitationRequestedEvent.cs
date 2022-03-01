namespace Mirai.Net.Data.Events.Concretes.Request;

public class NewInvitationRequestedEvent : RequestedEventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.NewInvitationRequested;
}