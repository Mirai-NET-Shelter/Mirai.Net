using Newtonsoft.Json;

namespace Mirai.Net.Data.Managers
{
    public class GroupFileInfo
    {
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}
        
        [JsonProperty("isFile")]
        public bool IsFile {get; set;}
    }
}