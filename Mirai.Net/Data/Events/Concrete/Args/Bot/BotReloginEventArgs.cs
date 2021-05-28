using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotReloginEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("qq")]
        public string QQ {get; set;}
    }
}