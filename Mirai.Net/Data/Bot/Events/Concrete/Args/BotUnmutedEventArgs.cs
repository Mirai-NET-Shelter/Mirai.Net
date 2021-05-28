using Newtonsoft.Json;

namespace Mirai.Net.Data.Bot.Events.Concrete.Args
{
    public class BotUnmutedEventArgs : EventArgsBase
    {
        public override string Type { get; set; }

        [JsonProperty("operator")]
        public BotMutedOperator Operator {get; set;}
        
        public class BotMutedOperator
        {
            [JsonProperty("id")]
            public string Id {get; set;}
        
            [JsonProperty("memberName")]
            public string Name {get; set;}
        
            [JsonProperty("permission")]
            public MemberPermissionType Permission {get; set;}
            
            [JsonProperty("group")]
            public OperationSenderGroup Group {get; set;}
        }
    }
}