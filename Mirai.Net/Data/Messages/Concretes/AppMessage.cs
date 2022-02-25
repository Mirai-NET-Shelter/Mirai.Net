using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

public class AppMessage : MessageBase
{
    public override Messages Type { get; set; } = Messages.App;

    [JsonProperty("content")] public string Content { get; set; }
}