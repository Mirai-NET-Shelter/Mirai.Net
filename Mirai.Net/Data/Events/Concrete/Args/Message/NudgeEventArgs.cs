using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concrete.Args.Message
{
    public class NudgeEventArgs : EventArgsBase
    {
        [JsonProperty("fromId")]
        public string FromId {get; set;}
        
        [JsonProperty("target")]
        public string Target {get; set;}
        
        [JsonProperty("subject")]
        public NudgeSubject Subject {get; set;}
        
        [JsonProperty("action")]
        public string Action {get; set;}
        
        [JsonProperty("suffix")]
        public string Suffix {get; set;}
        
        public class NudgeSubject
        {
            [JsonProperty("id")]
            public string Id {get; set;}
            
            [JsonProperty("kind")]
            public string Kind {get; set;}
        }
    }
}