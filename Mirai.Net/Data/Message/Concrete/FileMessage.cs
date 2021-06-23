using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class FileMessage : MessageBase
    {
        /// <summary>
        /// 文件识别id
        /// </summary>
        [JsonProperty("id")]
        public string FileId {get; set;}
        
        /// <summary>
        /// 文件名
        /// </summary>
        [JsonProperty("name")]
        public string Name {get; set;}
        
        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonProperty("size")]
        public long Size {get; set;}
    }
}