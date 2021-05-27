using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class AtMessage : MessageBase
    {
        public override string Type { get; set; } = "At";
        
        /// <summary>
        /// 群员QQ号
        /// </summary>
        [JsonProperty("target")]
        public string Target {get; set;}
        
        /// <summary>
        /// At时显示的文字，发送消息时无效，自动使用群名片
        /// </summary>
        [JsonProperty("display")]
        public string Display {get; set;}

        public AtMessage(string target = null, string display = null)
        {
            Target = target;
            Display = display;
        }
    }
}