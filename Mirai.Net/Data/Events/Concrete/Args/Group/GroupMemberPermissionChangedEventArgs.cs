using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupMemberPermissionChangedEventArgs : EventArgsBase
    {
        [JsonProperty("origin")]
        public MemberPermissionType Origin {get; set;}
        
        [JsonProperty("new")]
        public MemberPermissionType New {get; set;}
        
        [JsonProperty("current")]
        public MemberPermissionType Current {get; set;}
        
        [JsonProperty("member")]
        public GroupMember Member {get; set;}
    }
}