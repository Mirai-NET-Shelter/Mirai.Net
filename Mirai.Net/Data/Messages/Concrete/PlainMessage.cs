using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class PlainMessage : MessageBase
    {
        public override string Type { get; set; } = "Plain";
        
        [JsonProperty("text")]
        public string Text {get; set;}

        public PlainMessage(string text = null)
        {
            Text = text;
        }
    }
}