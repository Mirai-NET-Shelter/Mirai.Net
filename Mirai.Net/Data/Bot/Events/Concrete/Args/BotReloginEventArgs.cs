using Newtonsoft.Json;

namespace Mirai.Net.Data.Bot.Events.Concrete.Args
{
    public class BotReloginEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("qq")]
        public string QQ {get; set;}
    }
}