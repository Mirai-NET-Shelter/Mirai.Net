using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class JsonMessage : MessageBase
    {
        [JsonProperty("json")]
        public string Json {get; set;}
    }
}