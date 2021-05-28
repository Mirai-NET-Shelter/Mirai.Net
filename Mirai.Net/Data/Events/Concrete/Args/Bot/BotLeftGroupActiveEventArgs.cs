using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotLeftGroupActiveEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
    }
}