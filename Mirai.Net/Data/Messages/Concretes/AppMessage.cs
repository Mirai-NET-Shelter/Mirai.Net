using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class AppMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.App;

        [JsonProperty("app")] public string App { get; set; }
    }
}