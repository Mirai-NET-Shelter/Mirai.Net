using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class PokeMessage : MessageBase
    {
        public override string Type { get; set; } = "Poke";
        
        /// <summary>
        /// 戳一戳的类型
        /// "Poke": 戳一戳
        /// "ShowLove": 比心
        /// "Like": 点赞
        /// "Heartbroken": 心碎
        /// "SixSixSix": 666
        /// "FangDaZhao": 放大招
        /// </summary>
        [JsonProperty("name")]
        public string Name {get; set;}

        public PokeMessage(string name = null)
        {
            Name = name;
        }
    }
}