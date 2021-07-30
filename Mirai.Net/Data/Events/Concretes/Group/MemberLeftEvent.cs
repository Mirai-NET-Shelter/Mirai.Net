using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MemberLeftEvent : EventBase
    {
        public override Events Type { get; set; } = Events.MemberLeft;

        [JsonProperty("member")] public Member Member { get; set; }
    }
}