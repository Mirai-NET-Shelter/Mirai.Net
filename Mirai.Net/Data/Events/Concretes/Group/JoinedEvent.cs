using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class JoinedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.Joined;

        /// <summary>
        ///     加入的新群信息
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group { get; set; }
    }
}