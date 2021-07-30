namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupMutedAllEvent : GroupSettingChangedEventBase<bool>
    {
        public override Events Type { get; set; } = Events.GroupMutedAll;
    }
}