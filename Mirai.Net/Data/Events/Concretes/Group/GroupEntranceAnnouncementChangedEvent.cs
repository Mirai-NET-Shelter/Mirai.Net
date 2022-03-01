namespace Mirai.Net.Data.Events.Concretes.Group;

public class GroupEntranceAnnouncementChangedEvent : GroupSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupEntranceAnnouncementChanged;
}