using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class JsonMessage : MessageBase
    {
        public override string Type { get; set; } = "Json";
        
        [JsonProperty("json")]
        public string Json {get; set;}

        public JsonMessage(string json = null)
        {
            Json = json;
        }
    }
}