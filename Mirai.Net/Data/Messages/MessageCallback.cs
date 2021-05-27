using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages
{
    public class MessageCallback
    {
        [JsonProperty("code")]
        public string Code { get; set; }
        
        [JsonProperty("msg")]
        public string Message {get; set;}
        
        [JsonProperty("messageId")]
        public string MessageId {get; set;}
    }
}