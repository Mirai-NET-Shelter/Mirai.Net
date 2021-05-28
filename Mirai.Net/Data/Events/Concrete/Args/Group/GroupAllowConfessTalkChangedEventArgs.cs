using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Group
{
    public class GroupAllowConfessTalkChangedEventArgs : EventArgsBase
    {
        [JsonProperty("origin")]
        public bool Origin {get; set;}
        
        [JsonProperty("new")]
        public bool New {get; set;}
        
        [JsonProperty("current")]
        public bool Current {get; set;}
        
        [JsonProperty("group")]
        public OperationSenderGroup Group {get; set;}
        
        [JsonProperty("isByBot")]
        public bool ByBot {get; set;}
    }
}