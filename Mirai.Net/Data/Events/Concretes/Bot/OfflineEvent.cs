using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot
{
    /// <summary>
    /// Bot自身事件
    /// </summary>
    public class OfflineEvent : EventBase
    {
        [JsonProperty("qq")]
        public string QQ {get; private set;}

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.Offline;
    }
}