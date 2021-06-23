using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class SourceMessage : MessageBase
    {
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("id")]
        public string MessageId {get; set;}
        
        /// <summary>
        /// 消息发送时间戳
        /// </summary>
        [JsonProperty("time")]
        public string Time {get; set;}
    }
}