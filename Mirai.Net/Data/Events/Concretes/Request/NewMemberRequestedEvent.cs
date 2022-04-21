namespace Mirai.Net.Data.Events.Concretes.Request;

/// <summary>
/// 新成员申请
/// </summary>
public record NewMemberRequestedEvent : RequestedEventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.NewMemberRequested;
}