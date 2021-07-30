using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Friend
{
    public class FriendNickChangedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.FriendNickChanged;

        /// <summary>
        ///     发出此事件的好友
        /// </summary>
        [JsonProperty("friend")]
        public Shared.Friend Friend { get; set; }

        /// <summary>
        ///     原昵称
        /// </summary>
        [JsonProperty("from")]
        public string Origin { get; set; }

        /// <summary>
        ///     新昵称
        /// </summary>
        [JsonProperty("to")]
        public string New { get; set; }
    }
}