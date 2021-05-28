using Newtonsoft.Json;

namespace Mirai.Net.Data.Bot.Events.Concrete.Args
{
    public class BotLeftGroupActiveEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
    }
}