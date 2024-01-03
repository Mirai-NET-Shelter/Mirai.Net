namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 入群公告发生改变
/// </summary>
public record GroupEntranceAnnouncementChangedEvent : GroupSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupEntranceAnnouncementChanged;
}