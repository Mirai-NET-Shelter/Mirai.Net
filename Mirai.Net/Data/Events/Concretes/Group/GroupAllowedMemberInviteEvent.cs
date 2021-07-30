namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupAllowedMemberInviteEvent : GroupSettingChangedEventBase<bool>
    {
        public override Events Type { get; set; } = Events.GroupAllowedMemberInvite;
    }
}