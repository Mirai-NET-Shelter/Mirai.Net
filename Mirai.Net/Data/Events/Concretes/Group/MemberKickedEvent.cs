using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberKickedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.MemberKicked;

        [JsonProperty("member")] public Member Member { get; set; }

        [JsonProperty("operator")] public Member Operator { get; set; }
    }
}