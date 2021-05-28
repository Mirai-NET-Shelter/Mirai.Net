using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotMutedEventArgs : EventArgsBase
    {
        [JsonProperty("durationSeconds")]
        public string Period {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}