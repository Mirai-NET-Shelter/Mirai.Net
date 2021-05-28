using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupNameChangedEventArgs : EventArgsBase
    {
        [JsonProperty("origin")]
        public string Origin {get; set;}
        
        [JsonProperty("new")]
        public string New {get; set;}
        
        [JsonProperty("current")]
        public string Current {get; set;}
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
        
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
}