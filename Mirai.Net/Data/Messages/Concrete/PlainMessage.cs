using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class PlainMessage : MessageBase
    {
        public override string Type { get; set; } = "Plain";
        
        [JsonProperty("text")]
        public string Text {get; set;}
    }
}