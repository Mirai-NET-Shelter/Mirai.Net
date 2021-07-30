using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class QuoteMessage : MessageBase
    {
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
}