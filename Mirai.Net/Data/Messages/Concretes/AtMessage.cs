using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class AtMessage : MessageBase
    {
        public AtMessage(string target)
        {
            Target = target;
        }

        public AtMessage()
        {
        }

        /// <summary>
        ///     群员QQ号
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }

        /// <summary>
        ///     At时显示的文字，发送消息时无效，自动使用群名片
        /// </summary>
        [JsonProperty("display")]
        public string Display { get; set; }

        public override Messages Type { get; set; } = Messages.At;
    }
}