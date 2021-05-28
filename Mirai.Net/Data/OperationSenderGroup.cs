using Newtonsoft.Json;

namespace Mirai.Net.Data
{
    public class OperationSenderGroup
    {
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("permission")]
        public MemberPermissionType Permission {get; set;}
    }
}