using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Message
{
    public class MessageArgs
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageReceiveType Type { get; set; }
        
        [JsonProperty("messageChain")]
        public IEnumerable<MessageBase> Chain {get; set;}
        
        
    }
}