using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupMemberUnmutedEventArgs : EventArgsBase
    {
        [JsonProperty("durationSeconds")]
        public string Period {get; set;}
        
        [JsonProperty("member")]
        public GroupMember Member {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}