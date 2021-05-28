using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotJoinedGroupEventArgs : EventArgsBase
    {
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
    }
}