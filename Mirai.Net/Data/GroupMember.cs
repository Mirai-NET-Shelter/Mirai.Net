using Newtonsoft.Json;

namespace Mirai.Net.Data
{
    public class GroupMember
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