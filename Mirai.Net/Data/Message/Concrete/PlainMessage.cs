using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class PlainMessage : MessageBase
    {
        [JsonProperty("text")]
        public string Text {get; set;}
    }
}