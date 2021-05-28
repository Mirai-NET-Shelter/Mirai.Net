using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages
{
    public class MessageReceivedArgs
    {
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType Type {get; set;}
        
        [JsonProperty("messageChain")]
        public IEnumerable<MessageBase> MessageChain {get; set;}
        
        [JsonProperty("sender")]
        public MessageSender Sender {get; set;}
        
        public class MessageSender
        {
            [JsonProperty("id")]
            public string Id {get; set;}
            
            [JsonProperty("memberName")]
            public string Name {get; set;}
            
            [JsonProperty("permission")]
            public MemberPermissionType PermissionType {get; set;}
            
            [JsonProperty("group")]
            public MessageSender Group {get; set;}
        }
        
        public enum MessageType
        {
            GroupMessage,
            FriendMessage,
            TempMessage
        }
    }
}