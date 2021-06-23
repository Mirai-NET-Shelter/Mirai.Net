using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class AppMessage : MessageBase 
    {
        [JsonProperty("app")]
        public string App {get; set;}
    }
}