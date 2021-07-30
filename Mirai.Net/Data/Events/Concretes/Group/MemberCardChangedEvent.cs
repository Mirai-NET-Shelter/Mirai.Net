namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberCardChangedEvent : GroupMemberSettingChangedEventBase<string>
    {
        public override Events Type { get; set; } = Events.MemberCardChanged;
    }
}