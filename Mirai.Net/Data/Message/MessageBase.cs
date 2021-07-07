using Mirai.Net.Data.Message.Concrete;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Message
{
    /// <summary>
    /// 如果直接用string则以传入的string隐式转换为一个PlainMessage对象
    /// </summary>
    public class MessageBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public virtual MessageType Type {get; init; }

        public static implicit operator MessageBase(string s)
        {
            return new PlainMessage
            {
                Type = MessageType.Plain,
                Text = s
            };
        }
    }
}