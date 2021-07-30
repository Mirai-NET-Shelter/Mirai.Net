using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages
{
    public class MessageBase
    {
        [JsonProperty("type")]
        public virtual Messages Type {get; set; }
    }
}