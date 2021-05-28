using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupMemberCardChangedEventArgs : EventArgsBase
    {
        [JsonProperty("origin")]
        public string Origin {get; set;}
        
        [JsonProperty("new")]
        public string New {get; set;}
        
        [JsonProperty("current")]
        public string Current {get; set;}
        
        [JsonProperty("member")]
        public GroupMember Member {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}