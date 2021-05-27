using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class XmlMessage : MessageBase
    {
        public override string Type { get; set; } = "Xml";
        
        [JsonProperty("xml")]
        public string Xml {get; set;}

        public XmlMessage(string xml = null)
        {
            Xml = xml;
        }
    }
}