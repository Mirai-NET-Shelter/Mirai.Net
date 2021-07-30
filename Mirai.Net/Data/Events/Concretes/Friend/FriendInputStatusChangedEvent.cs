using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Friend
{
    public class FriendInputStatusChangedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.FriendInputStatusChanged;

        /// <summary>
        ///     当前输出状态是否正在输入
        /// </summary>
        [JsonProperty("inputting")]
        public bool Inputting { get; set; }

        /// <summary>
        ///     发出此事件的好友
        /// </summary>
        [JsonProperty("friend")]
        public Shared.Friend Friend { get; set; }
    }
}