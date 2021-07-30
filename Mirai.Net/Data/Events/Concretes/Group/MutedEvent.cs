using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class MutedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.Muted;

        /// <summary>
        ///     被禁言的时间，单位：秒
        /// </summary>
        [JsonProperty("durationSeconds")]
        public string Period { get; set; }

        /// <summary>
        ///     禁言bot的操作者
        /// </summary>
        [JsonProperty("operator")]
        public Member Operator { get; set; }
    }
}