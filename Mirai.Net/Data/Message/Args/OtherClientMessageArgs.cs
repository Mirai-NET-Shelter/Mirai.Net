using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Args
{
    public class OtherClientMessageArgs : MessageArgs
    {
        [JsonProperty("sender")]
        public OtherClientSender Sender {get; set;}

        public class OtherClientSender
        {
            [JsonProperty("id")]
            public string Id {get; set;}
            
            [JsonProperty("platform")]
            public string Platform {get; set;}
        }
    }
}