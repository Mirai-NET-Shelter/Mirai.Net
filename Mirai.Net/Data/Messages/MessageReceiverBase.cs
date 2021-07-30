using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages
{
    public class MessageReceiverBase
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public virtual MessageReceivers Type { get; set; }
        
        [JsonProperty("messageChain")]
        public IEnumerable<MessageBase> MessageChain { get; set; }
    }
}