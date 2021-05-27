using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class FileMessage : MessageBase
    {
        public override string Type { get; set; } = "File";
        
        /// <summary>
        /// 文件唯一id
        /// </summary>
        [JsonProperty("id")]
        public string Id {get; set;}
        
        /// <summary>
        /// 服务器需要的ID
        /// </summary>
        [JsonProperty("internalId")]
        public string InternalId {get; set;}
        
        /// <summary>
        /// 文件名字
        /// </summary>
        [JsonProperty("name")]
        public string Name {get; set;}
        
        /// <summary>
        /// 文件大小
        /// </summary>
        [JsonProperty("size")]
        public string Size {get; set;}

        public FileMessage(string id = null, string internalId = null, string name = null, string size = null)
        {
            Id = id;
            InternalId = internalId;
            Name = name;
            Size = size;
        }
    }
}