using Mirai.Net.Data.Messages;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Message
{
    public class GroupMessageRecalledEventArgs : MessageBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("authorId")]
        public string SenderQQ {get; set;}
        
        [JsonProperty("messageId")]
        public string MessageId {get; set;}
        
        [JsonProperty("time")]
        public string Time {get; set;}
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
        
        [JsonProperty("operator")]
        public GroupMessageRecallOperator Operator {get; set;}

        public class GroupMessageRecallOperator
        {
            [JsonProperty("id")]
            public string Id {get; set;}
            
            [JsonProperty("memberName")]
            public string Name {get; set;}
            
            [JsonProperty("permission")]
            public MemberPermissionType Permission {get; set;}
            
            [JsonProperty("group")]
            public OperationSenderGroup Group {get; set;}
        }
    }
}