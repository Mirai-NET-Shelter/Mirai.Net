using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Friend
{
    public class FriendRecalledEvent : EventBase
    {
        public override Events Type { get; set; } = Events.FriendRecalled;

        /// <summary>
        ///     原消息发送者的QQ号
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId { get; set; }

        /// <summary>
        ///     原消息messageId
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId { get; set; }

        /// <summary>
        ///     原消息发送时间戳
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        ///     好友QQ号或BotQQ号
        /// </summary>
        [JsonProperty("operator")]
        public string Operator { get; set; }
    }
}