using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class KickedEvent : EventBase
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.Kicked;
        
        /// <summary>
        /// bot被踢的群信息
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group { get; set; }
    }
}