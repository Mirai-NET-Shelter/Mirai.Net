using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot
{
    public class DroppedEvent : EventBase
    {
        [JsonProperty("qq")] public string QQ { get; private set; }

        public override Events Type { get; set; } = Events.Dropped;
    }
}