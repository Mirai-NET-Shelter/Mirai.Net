using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberUnmutedEvent : EventBase
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.MemberUnmuted;
        
        [JsonProperty("Member")]
        public Member Member {get; set;}
        
        [JsonProperty("Operator")]
        public Member Operator {get; set;}
    }
}