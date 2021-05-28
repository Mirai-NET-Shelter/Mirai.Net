using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotLeftGroupActiveEventArgs : EventArgsBase
    {
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
    }
}