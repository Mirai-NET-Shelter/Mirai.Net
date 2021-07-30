using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class FileMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.File;

        /// <summary>
        ///     文件识别id
        /// </summary>
        [JsonProperty("id")]
        public string FileId { get; set; }

        /// <summary>
        ///     文件名
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     文件大小
        /// </summary>
        [JsonProperty("size")]
        public long Size { get; set; }
    }
}