using Newtonsoft.Json;

namespace Mirai.Net.Data.Managers
{
    public class GroupMemberInfo
    {
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("nick")]
        public string Nick {get; set;}
        
        [JsonProperty("specialTitle")]
        public string Title {get; set;}
    }
}