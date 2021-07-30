using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class ForwardMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.Forward;

        /// <summary>
        ///     消息节点
        /// </summary>
        [JsonProperty("nodeList")]
        public IEnumerable<ForwardNode> NodeList { get; set; }

        public class ForwardNode
        {
            /// <summary>
            ///     发送人QQ号
            /// </summary>
            [JsonProperty("senderId")]
            public string SenderId { get; set; }

            /// <summary>
            ///     发送时间
            /// </summary>
            [JsonProperty("time")]
            public string Time { get; set; }

            /// <summary>
            ///     显示名称
            /// </summary>
            [JsonProperty("senderName")]
            public string SenderName { get; set; }

            /// <summary>
            ///     消息数组
            /// </summary>
            [JsonProperty("messageChain")]
            public IEnumerable<MessageBase> MessageChain { get; set; }

            /// <summary>
            ///     可以只使用消息messageId，从缓存中读取一条消息作为节点
            /// </summary>
            [JsonProperty("sourceId")]
            public string SourceId { get; set; }
        }
    }
}