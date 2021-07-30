using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group
{
    public class LeftEvent : EventBase
    {
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Events Type { get; set; } = Events.Left;
        
        /// <summary>
        /// 退出的群信息
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group {get; set;}
    }
}