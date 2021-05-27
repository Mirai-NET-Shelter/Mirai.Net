using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class ForwardMessage : MessageBase
    {
        public override string Type { get; set; } = "Forward";
        
        [JsonProperty("title")]
        public string Title {get; set;}
        
        [JsonProperty("brief")]
        public string Brief {get; set;}
        
        [JsonProperty("source")]
        public string Source {get; set;}
        
        [JsonProperty("summary")]
        public string Summary {get; set;}
        
        [JsonProperty("nodeList")]
        public IEnumerable<Node> NodeList {get; set;}

        public class Node
        {
            [JsonProperty("senderId")]
            public string SenderId {get; set;}
            
            [JsonProperty("time")]
            public string Time {get; set;}
            
            [JsonProperty("senderName")]
            public string SenderName {get; set;}
            
            [JsonProperty("messageChain")]
            public IEnumerable<MessageBase> MessageChain {get; set;}
        }
    }
}