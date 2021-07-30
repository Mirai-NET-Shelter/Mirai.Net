using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class XmlMessage : MessageBase
    {
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Messages Type { get; set; } = Messages.Xml;
        
        [JsonProperty("xml")]
        public string Xml {get; set;}
    }
}