using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupMemberKickedEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("member")]
        public GroupMember Member {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}