namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupAllowedConfessTalkChanged : GroupSettingChangedEventBase<bool>
    {
        public override Events Type { get; set; } = Events.GroupAllowedConfessTalk;
    }
}