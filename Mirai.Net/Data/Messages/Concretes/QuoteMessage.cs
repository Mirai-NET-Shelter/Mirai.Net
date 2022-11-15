using Newtonsoft.Json;
using System.Collections.Generic;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 引用消息
/// </summary>
public record QuoteMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Quote;

    /// <summary>
    ///     被引用回复的原消息的messageId
    /// </summary>
    [JsonProperty("id")]
    public string MessageId { get; set; }

    /// <summary>
    ///     被引用回复的原消息所接收的群号，当为好友消息时为0
    /// </summary>
    [JsonProperty("groupId")]
    public string GroupId { get; set; }

    /// <summary>
    ///     被引用回复的原消息的发送者的QQ号
    /// </summary>
    [JsonProperty("senderId")]
    public string SenderId { get; set; }

    /// <summary>
    ///     被引用回复的原消息的接收者者的QQ号（或群号）
    /// </summary>
    [JsonProperty("targetId")]
    public string TargetId { get; set; }

    /// <summary>
    ///     被引用回复的原消息的消息链对象
    /// </summary>
    [JsonProperty("origin")]
    public IEnumerable<MessageBase> Origin { get; set; }
}