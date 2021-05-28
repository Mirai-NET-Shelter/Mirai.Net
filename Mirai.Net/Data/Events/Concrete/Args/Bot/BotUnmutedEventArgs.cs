using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotUnmutedEventArgs : EventArgsBase
    {
        public override string Type { get; set; }

        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}