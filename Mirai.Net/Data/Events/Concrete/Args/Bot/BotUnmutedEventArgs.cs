using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotUnmutedEventArgs : EventArgsBase
    {
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}