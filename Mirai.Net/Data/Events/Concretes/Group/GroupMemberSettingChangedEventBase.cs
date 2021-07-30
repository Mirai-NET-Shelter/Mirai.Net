using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public abstract class GroupMemberSettingChangedEventBase<T> : EventBase
    {
        [JsonProperty("origin")] public T Origin { get; set; }

        [JsonProperty("current")] public T Current { get; set; }

        /// <summary>
        ///     产生此事件的群
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group { get; set; }

        /// <summary>
        ///     操作者
        /// </summary>
        [JsonProperty("member")]
        public Member Member { get; set; }
    }
}