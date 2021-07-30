namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupAllowedAnonymousChatEvent : GroupSettingChangedEventBase<bool>
    {
        public override Events Type { get; set; } = Events.GroupAllowedAnonymousChat;
    }
}