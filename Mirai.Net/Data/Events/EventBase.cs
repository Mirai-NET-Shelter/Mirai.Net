using AHpx.Extensions.StringExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events
{
    public class EventBase
    {
        protected EventBase()
        {
        }

        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public virtual Events Type { get; set; }

        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}