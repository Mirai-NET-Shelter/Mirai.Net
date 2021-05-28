using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotOfflinePassiveEventArgs : EventArgsBase
    {
        [JsonProperty("qq")]
        public string QQ {get; set;}
    }
}