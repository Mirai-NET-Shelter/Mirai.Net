using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Shared
{
    public class File
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("path")] public string Path { get; set; }

        [JsonProperty("parent")] public File Parent { get; set; }

        [JsonProperty("isFile")] public bool IsFile { get; set; }

        [JsonProperty("isDirectory")] public bool IsDirectory { get; set; }

        [JsonProperty("contact")] public FileUploader Contact { get; set; }
        
        [JsonProperty("downloadInfo")]
        public string DownloadInfo {get; set;}

        public class FileUploader
        {
            [JsonProperty("id")] public string Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("permission")]
            [JsonConverter(typeof(StringEnumConverter))]
            public Permissions Permission { get; set; }
        }
        
        public class FileDownloadInfo
        {
            [JsonProperty("sha1")]
            public string Sha1 {get; set;}
            
            [JsonProperty("md5")]
            public string Md5 {get; set;}
            
            [JsonProperty("url")]
            public string Url {get; set;}
        }
    }
}