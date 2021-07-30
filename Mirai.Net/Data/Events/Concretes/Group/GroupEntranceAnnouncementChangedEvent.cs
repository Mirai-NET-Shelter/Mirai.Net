namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupEntranceAnnouncementChangedEvent : GroupSettingChangedEventBase<string>
    {
        public override Events Type { get; set; } = Events.GroupEntranceAnnouncementChanged;
    }
}