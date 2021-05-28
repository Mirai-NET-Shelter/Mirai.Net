using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotOfflineActiveEventArgs : EventArgsBase
    {
        [JsonProperty("qq")]
        public string QQ {get; set;}
    }
}