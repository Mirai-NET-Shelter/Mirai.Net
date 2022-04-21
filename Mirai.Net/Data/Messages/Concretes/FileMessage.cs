using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 文件
/// </summary>
public record FileMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.File;

    /// <summary>
    ///     文件识别id
    /// </summary>
    [JsonProperty("id")]
    public string FileId { get; set; }

    /// <summary>
    ///     文件名
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///     文件大小
    /// </summary>
    [JsonProperty("size")]
    public long Size { get; set; }
}