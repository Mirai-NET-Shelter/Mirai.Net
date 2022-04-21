namespace Mirai.Net.Data.Events.Concretes.Request;

/// <summary>
/// 新的好友请求
/// </summary>
public record NewFriendRequestedEvent : RequestedEventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.NewFriendRequested;
}