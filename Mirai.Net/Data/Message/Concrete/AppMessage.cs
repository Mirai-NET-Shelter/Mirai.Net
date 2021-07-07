using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class AppMessage : MessageBase
    {
        public override MessageType Type { get; init; } = MessageType.App;

        [JsonProperty("app")]
        public string App {get; set;}
    }
}