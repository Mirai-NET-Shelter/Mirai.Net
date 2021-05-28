using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupMemberKickedEventArgs : EventArgsBase
    {
        [JsonProperty("member")]
        public GroupMember Member {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}