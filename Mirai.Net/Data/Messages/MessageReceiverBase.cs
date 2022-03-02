using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages;

/// <summary>
/// 消息接收器基类
/// </summary>
public class MessageReceiverBase
{
    /// <summary>
    /// 消息接收器类型
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MessageReceivers Type { get; set; }

    /// <summary>
    /// 接受到的消息链
    /// </summary>
    [JsonProperty("messageChain")] public MessageChain MessageChain { get; set; }
}