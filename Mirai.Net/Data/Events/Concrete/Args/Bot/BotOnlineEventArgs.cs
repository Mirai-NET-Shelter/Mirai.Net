using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotOnlineEventArgs : EventArgsBase
    {
        [JsonProperty("qq")]
        public string QQ {get; set;}
    }
}