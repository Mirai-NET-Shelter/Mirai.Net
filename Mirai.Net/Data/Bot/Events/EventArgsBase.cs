using Newtonsoft.Json;

namespace Mirai.Net.Data.Bot.Events
{
    public class EventArgsBase
    {
        [JsonProperty("type")]
        public string Type {get; set;}

        protected EventArgsBase()
        {
        }
    }
}