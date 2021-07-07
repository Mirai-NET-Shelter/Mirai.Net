using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Files
{
    public class File
    {
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}
        
        [JsonProperty("parent")]
        public File Parent {get; set;}
        
        [JsonProperty("contact")]
        public FileContact Contact {get; set;}
        
        public class FileContact
        {
            [JsonProperty("id")]
            public string Id {get; set;}
            
            [JsonProperty("name")]
            public string Name {get; set;}
            
            [JsonProperty("permission")]
            public GroupPermission Permission {get; set;}
        }
        
        [JsonProperty("isFile")]
        public bool IsFile {get; set;}
        
        [JsonProperty("isDirectory")]
        public bool IsDirectory {get; set;}
    }
}