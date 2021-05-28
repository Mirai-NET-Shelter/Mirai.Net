using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupAllowAnonymousChatChangedEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("origin")]
        public bool Origin {get; set;}
        
        [JsonProperty("new")]
        public bool New {get; set;}
        
        [JsonProperty("current")]
        public bool Current {get; set;}
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
        
        public class GroupNameChangedOperator
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