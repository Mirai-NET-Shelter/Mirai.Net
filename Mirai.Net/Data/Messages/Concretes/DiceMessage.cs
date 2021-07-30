using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class DiceMessage : MessageBase
    {
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Messages Type { get; set; } = Messages.Dice;
        
        /// <summary>
        /// 点数
        /// </summary>
        [JsonProperty("value")]
        public string Value {get; set;}
    }
}