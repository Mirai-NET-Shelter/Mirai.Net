using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
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

        public override Messages Type { get; set; } = Messages.Source;
    }
}