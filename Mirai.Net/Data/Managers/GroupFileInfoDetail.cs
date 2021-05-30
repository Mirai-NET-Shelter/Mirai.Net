using Newtonsoft.Json;

namespace Mirai.Net.Data.Managers
{
    public class GroupFileInfoDetail
    {
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}

        [JsonProperty("length")]
        public string Length {get; set;}
        
        [JsonProperty("downloadTimes")]
        public string DownloadTimes {get; set;}
        
        [JsonProperty("uploaderId")]
        public string UploaderId {get; set;}
        
        [JsonProperty("uploadTime")]
        public string UploadTime {get; set;}
        
        [JsonProperty("lastModifyTime")]
        public string LastModifyTime {get; set;}
        
        [JsonProperty("downloadUrl")]
        public string DownloadUrl {get; set;}
        
        [JsonProperty("sha1")]
        public string Sha1 {get; set;}
        
        [JsonProperty("md5")]
        public string Md5 {get; set;}
    }
}