using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class AppMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.App;
        
        [JsonProperty("app")]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public string App {get; set;}
    }
}