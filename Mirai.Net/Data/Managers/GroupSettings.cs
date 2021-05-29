using Newtonsoft.Json;

namespace Mirai.Net.Data.Managers
{
    public class GroupSettings
    {
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("announcement")]
        public string Announcement {get; set;}
        
        [JsonProperty("confessTalk")]
        public bool ConfessTalk {get; set;}
        
        [JsonProperty("allowMemberInvite")]
        public bool AllowMemberInvite {get; set;}
        
        [JsonProperty("autoApprove")]
        public bool AutoApprove {get; set;}
        
        [JsonProperty("anonymousChat")]
        public bool AnonymousChat {get; set;}
    }
}