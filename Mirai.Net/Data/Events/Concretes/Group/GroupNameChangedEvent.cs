namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupNameChangedEvent : GroupSettingChangedEventBase<string>
    {
        public override Events Type { get; set; } = Events.GroupNameChanged;
    }
}