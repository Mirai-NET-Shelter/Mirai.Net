using Manganese.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages;

/// <summary>
/// 所有消息的基类
/// </summary>
public class MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Messages Type { get; set; }

    /// <summary>
    /// 实际上是转换成json文本
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.ToJsonString();
    }

    /// <summary>
    /// 自动转换成消息链
    /// </summary>
    /// <param name="msg1"></param>
    /// <param name="msg2"></param>
    /// <returns></returns>
    public static MessageChain operator +(MessageBase msg1, MessageBase msg2)
    {
        return new MessageChain { msg1, msg2 };
    }
}