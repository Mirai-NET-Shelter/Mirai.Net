using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberJoinedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.MemberJoined;

        [JsonProperty("member")] public Member Member { get; set; }
    }
}