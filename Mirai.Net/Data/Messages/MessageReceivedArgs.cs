using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages
{
    public class MessageReceivedArgs
    {
        [JsonProperty("type")]
        public string Type {get; set;}
        
        [JsonProperty("messageChain")]
        public IEnumerable<MessageBase> MessageChain {get; set;}
        
        [JsonProperty("sender")]
        public MessageSender Sender {get; set;}
        
        public class MessageSender
        {
            [JsonProperty("id")]
            public string Id {get; set;}
            
            [JsonProperty("name")]
            public string Name {get; set;}
            
            [JsonProperty("permission")]
            public string Permission {get; set;}
            
            [JsonProperty("group")]
            public MessageSender Group {get; set;}
        }
    }
}