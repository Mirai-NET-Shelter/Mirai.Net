using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupMemberLeftGroupActiveEventArgs : EventArgsBase
    {
        [JsonProperty("member")]
        public GroupMember Member {get; set;}
    }
}