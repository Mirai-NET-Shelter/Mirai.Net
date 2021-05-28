using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Bot
{
    public class BotPermissionChangedEventArgs : EventArgsBase
    {
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