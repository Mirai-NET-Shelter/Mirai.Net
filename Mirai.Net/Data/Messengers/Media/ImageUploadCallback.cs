using Newtonsoft.Json;

namespace Mirai.Net.Data.Messengers.Media
{
    public class ImageUploadCallback
    {
        [JsonProperty("imageId")]
        public string ImageId {get; set;}
        
        [JsonProperty("url")]
        public string Url {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}
    }
}