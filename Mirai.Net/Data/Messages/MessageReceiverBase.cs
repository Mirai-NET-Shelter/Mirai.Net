using System.Threading.Tasks;
using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages;

/// <summary>
/// 消息接收器基类
/// </summary>
public record MessageReceiverBase
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

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="chain">消息链</param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException">直接尝试呼叫此方法时掷出</exception>
    public virtual Task<string> SendMessageAsync(MessageChain chain)
    {
        throw new NotSupportedException("Direct call to virtual MessageReceiverBase.SendMessageAsync is not supported.");
    }
}