using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class PlainMessage : MessageBase
    {
        public override string Type { get; set; } = "Plain";
        
        /// <summary>
        /// 文字消息
        /// </summary>
        [JsonProperty("text")]
        public string Text {get; set;}

        public PlainMessage(string text = null)
        {
            Text = text;
        }
    }
}