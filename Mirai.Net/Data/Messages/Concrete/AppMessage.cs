using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class AppMessage : MessageBase
    {
        public override string Type { get; set; } = "App";
        
        [JsonProperty("content")]
        public string Content {get; set;}

        public AppMessage(string content = null)
        {
            Content = content;
        }
    }
}