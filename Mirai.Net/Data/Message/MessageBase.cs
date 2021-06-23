using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Message
{
    public class MessageBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public MessageType Type {get; init; }
    }
}