using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Request
{
    public abstract class RequestedEventBase : EventBase
    {
        [JsonProperty("eventId")] public string EventId { get; set; }

        [JsonProperty("fromId")] public string FromId { get; set; }

        [JsonProperty("groupId")] public string GroupId { get; set; }

        [JsonProperty("nick")] public string Nick { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }
}