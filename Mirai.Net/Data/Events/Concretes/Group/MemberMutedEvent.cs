using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberMutedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.MemberMuted;

        [JsonProperty("durationSeconds")] public string Period { get; set; }

        [JsonProperty("Member")] public Member Member { get; set; }

        [JsonProperty("Operator")] public Member Operator { get; set; }
    }
}