using Newtonsoft.Json;

namespace Mirai.Net.Data.Messengers.Media
{
    public class VoiceUploadCallback
    {
        [JsonProperty("voiceId")]
        public string VoiceId {get; set;}
        
        [JsonProperty("url")]
        public string Url {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}
    }
}