namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberTitleChangedEvent : GroupMemberSettingChangedEventBase<string>
    {
        public override Events Type { get; set; } = Events.MemberTitleChanged;
    }
}