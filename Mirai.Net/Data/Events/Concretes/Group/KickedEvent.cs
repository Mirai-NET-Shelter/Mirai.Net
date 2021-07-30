using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class KickedEvent : EventBase
    {
        public override Events Type { get; set; } = Events.Kicked;

        /// <summary>
        ///     bot被踢的群信息
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group { get; set; }
    }
}