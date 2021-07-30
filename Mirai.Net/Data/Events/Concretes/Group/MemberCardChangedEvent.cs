namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberCardChangedEvent : GroupMemberSettingChangedEventBase<string>
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.MemberCardChanged;
    }
}