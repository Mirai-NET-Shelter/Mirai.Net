using Mirai.Net.Data.Messages;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Message
{
    public class GroupMessageRecalledEventArgs : MessageBase
    {
        [JsonProperty("authorId")]
        public string SenderQQ {get; set;}
        
        [JsonProperty("messageId")]
        public string MessageId {get; set;}
        
        [JsonProperty("time")]
        public string Time {get; set;}
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}