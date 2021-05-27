using Newtonsoft.Json;

namespace Mirai.Net.Data.Messengers.Media
{
    public class FileUploadCallback
    {
        [JsonProperty("code")]
        public string Code {get; set;}
        
        [JsonProperty("msg")]
        public string Message {get; set;}
        
        [JsonProperty("id")]
        public string Id {get; set;}
    }
}