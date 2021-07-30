using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class JsonMessage : MessageBase
    {
        [JsonProperty("json")] public string Json { get; set; }

        public override Messages Type { get; set; } = Messages.Json;
    }
}