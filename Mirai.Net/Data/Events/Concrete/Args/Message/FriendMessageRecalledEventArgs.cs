using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Message
{
    public class FriendMessageRecalledEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("authorId")]
        public string SenderQQ {get; set;}
        
        [JsonProperty("messageId")]
        public string MessageId {get; set;}
        
        [JsonProperty("time")]
        public string Time {get; set;}
        
        [JsonProperty("operator")]
        public string Operator {get; set;}
    }
}