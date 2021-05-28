using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotKickedEventArgs : EventArgsBase
    {
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
    }
}