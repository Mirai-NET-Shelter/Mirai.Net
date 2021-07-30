using System.Collections.Generic;
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
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public virtual Events Type {get; set; }

        public override string ToString()
        {
            return this.ToJsonString();
        }
    }
}