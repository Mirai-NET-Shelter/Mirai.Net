using Manganese.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Messages;

public class MessageBase
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Messages Type { get; set; }

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