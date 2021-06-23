using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Message
{
    public class MessageArgs
    {
        [JsonProperty("type")]
        public MessageReceiveType Type { get; set; }
        
        [JsonProperty("messageChain")]
        public IEnumerable<MessageBase> Chain {get; set;}
        
        
    }
}