using Newtonsoft.Json;

namespace Mirai.Net.Data.Contact
{
    public class BotFriend
    {
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("nickname")]
        public string Nick {get; set;}
        
        [JsonProperty("remark")]
        public string Remark {get; set;}
    }
}