using Mirai.Net.Data.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class PermissionChangedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.PermissionChanged;

        [JsonProperty("origin")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Origin { get; set; }

        [JsonProperty("current")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Current { get; set; }

        [JsonProperty("group")] public Shared.Group Group { get; set; }
    }
}