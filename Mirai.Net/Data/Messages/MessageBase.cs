using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages
{
    public class MessageBase
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Messages Type { get; set; }
    }
}