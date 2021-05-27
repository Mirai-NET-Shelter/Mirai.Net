using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class SourceMessage : MessageBase
    {
        [JsonProperty("type")]
        public override string Type { get; set; } = "Source";
        
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}