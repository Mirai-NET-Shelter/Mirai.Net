using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class XmlMessage : MessageBase
    {
        [JsonProperty("xml")]
        public string Xml {get; set;}
        
        public override MessageType Type { get; init; } = MessageType.Xml;
    }
}