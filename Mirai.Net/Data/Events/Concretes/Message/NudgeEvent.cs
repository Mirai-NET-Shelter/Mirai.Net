using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Message
{
    public class NudgeEvent : EventBase
    {
        [JsonProperty("fromId")] public string FromId { get; set; }

        [JsonProperty("target")] public string Target { get; set; }

        [JsonProperty("action")] public string Action { get; set; }

        [JsonProperty("suffix")] public string Suffix { get; set; }

        public override Events Type { get; set; } = Events.Nudged;

        public class NudgeSubject
        {
            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("kind")] public string Kind { get; set; }
        }
    }
}