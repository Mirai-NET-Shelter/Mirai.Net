using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public abstract class GroupSettingChangedEventBase<T> : EventBase
    {
        /// <summary>
        ///     原来的
        /// </summary>
        [JsonProperty("origin")]
        public T Origin { get; set; }

        /// <summary>
        ///     目前的
        /// </summary>
        [JsonProperty("current")]
        public T Current { get; set; }

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