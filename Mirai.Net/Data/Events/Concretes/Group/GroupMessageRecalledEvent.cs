using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class GroupMessageRecalledEvent : EventBase
    {
        public override Events Type { get; set; } = Events.GroupMessageRecalled;

        /// <summary>
        ///     原消息发送者的QQ号
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        ///     消息id
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     撤回时间戳
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        ///     产生此事件的群
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group { get; set; }

        /// <summary>
        ///     操作者
        /// </summary>
        [JsonProperty("operator")]
        public Member Operator { get; set; }
    }
}