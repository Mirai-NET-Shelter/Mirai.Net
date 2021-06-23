using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class AtMessage : MessageBase
    {
        /// <summary>
        /// 群员QQ号
        /// </summary>
        [JsonProperty("target")]
        public string Target {get; set;}
        
        /// <summary>
        /// At时显示的文字，发送消息时无效，自动使用群名片
        /// </summary>
        [JsonProperty("display")]
        public string Display {get; set;}
        
        public override MessageType Type { get; init; } = MessageType.At;
    }
}