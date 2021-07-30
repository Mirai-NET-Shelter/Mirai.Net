using Mirai.Net.Data.Shared;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberPermissionChangedEvent : GroupMemberSettingChangedEventBase<Permissions>
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.MemberPermissionChanged;
    }
}