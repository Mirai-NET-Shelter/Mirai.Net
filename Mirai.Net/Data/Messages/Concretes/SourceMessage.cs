using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 源消息
/// <remarks>仅在接收消息时有效，且总是消息链的第一个元素</remarks>
/// </summary>
public class SourceMessage : MessageBase
{
    /// <summary>
    ///     消息id
    /// </summary>
    [JsonProperty("id")]
    public string MessageId { get; set; }

    /// <summary>
    ///     消息发送时间戳
    /// </summary>
    [JsonProperty("time")]
    public string Time { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Source;
}