using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class DiceMessage : MessageBase
    {
        /// <summary>
        /// 点数
        /// </summary>
        [JsonProperty("value")]
        public string Value {get; set;}
    }
}