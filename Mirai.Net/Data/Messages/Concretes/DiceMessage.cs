using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class DiceMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.Dice;

        /// <summary>
        ///     点数
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}