using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupNewMemberJoinedEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("member")]
        public string Member {get; set;}
        
        public class NewMember
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