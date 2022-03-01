using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared;

public class OtherClient
{
    [JsonProperty("id")] public int Id { get; set; }

    [JsonProperty("platform")] public string Platform { get; set; }
}