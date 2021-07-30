using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class PokeMessage : MessageBase
    {
        /// <summary>
        ///     "Poke": 戳一戳
        ///     "ShowLove": 比心
        ///     "Like": 点赞
        ///     "Heartbroken": 心碎
        ///     "SixSixSix": 666
        ///     "FangDaZhao": 放大招
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        public override Messages Type { get; set; } = Messages.Poke;
    }
}