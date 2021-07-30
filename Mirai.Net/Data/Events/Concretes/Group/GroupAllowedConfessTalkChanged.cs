namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupAllowedConfessTalkChanged : GroupSettingChangedEventBase<bool>
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.GroupAllowedConfessTalk;
    }
}