using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages
{
    public class MessageReceiverBase
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual MessageReceivers Type { get; set; }

        [JsonProperty("messageChain")] public IEnumerable<MessageBase> MessageChain { get; set; }
    }
}