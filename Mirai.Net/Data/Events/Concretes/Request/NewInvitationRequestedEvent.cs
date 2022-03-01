namespace Mirai.Net.Data.Events.Concretes.Request;

/// <summary>
/// 新的邀请（邀请bot加入某群）
/// </summary>
public class NewInvitationRequestedEvent : RequestedEventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.NewInvitationRequested;
}