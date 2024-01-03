using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 其它客户端
/// </summary>
public record OtherClient
{
    /// <summary>
    /// 客户端id
    /// </summary>
    [JsonProperty("id")] public int Id { get; set; }

    /// <summary>
    /// 平台
    /// </summary>
    [JsonProperty("platform")] public string Platform { get; set; }
}