using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared
{
    /// <summary>
    /// 群公告
    /// </summary>
    public record Announcement
    {
        /// <summary>
        /// 群信息
        /// </summary>
        [JsonProperty("group")]
        public Group Group { get; set; }

        /// <summary>
        /// 群公告内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// 发布者账号
        /// </summary>
        [JsonProperty("senderID")]
        public string SenderID { get; set; }

        /// <summary>
        /// 公告唯一id
        /// </summary>
        [JsonProperty("fid")]
        public string Fid { get; set; }

        /// <summary>
        /// 是否所有群成员已确认
        /// </summary>
        [JsonProperty("allConfirmed")]
        public bool AllConfirmed { get; set; }

        /// <summary>
        /// 确认群成员人数
        /// </summary>
        [JsonProperty("confirmedMembersCount")]
        public string ConfirmedMembersCount { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        [JsonProperty("publicationTime")]
        public string PublicationTime { get; set; }

    }
}
