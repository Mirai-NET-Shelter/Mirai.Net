using Newtonsoft.Json;

namespace Mirai.Net.Data.Events
{
    public class EventArgsBase
    {
        [JsonProperty("type")]
        public virtual string Type {get; set;}

        protected EventArgsBase()
        {
        }
    }
}