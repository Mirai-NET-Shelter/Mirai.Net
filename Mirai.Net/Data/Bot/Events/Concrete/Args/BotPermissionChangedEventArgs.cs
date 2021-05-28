using Newtonsoft.Json;

namespace Mirai.Net.Data.Bot.Events.Concrete.Args
{
    public class BotPermissionChangedEventArgs : EventArgsBase
    {
        public override string Type { get; set; }
        
        [JsonProperty("origin")]
        public MemberPermissionType Origin {get; set;}
        
        [JsonProperty("new")]
        public MemberPermissionType New {get; set;}
        
        [JsonProperty("current")]
        public MemberPermissionType Current {get; set;}
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
    }
}