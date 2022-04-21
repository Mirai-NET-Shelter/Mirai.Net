using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// qq表情
/// </summary>
public record FaceMessage : MessageBase
{
    /// <summary>
    ///     QQ表情编号，可选，优先高于<see cref="Name"/>
    /// </summary>
    [JsonProperty("faceId")]
    public string FaceId { get; set; }

    /// <summary>
    ///     QQ表情拼音，可选
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Face;
}