using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class AtAllMessage : MessageBase
    {
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public override Messages Type { get; set; } = Messages.AtAll;
    }
}