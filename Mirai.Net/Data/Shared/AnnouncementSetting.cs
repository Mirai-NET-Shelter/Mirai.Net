using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared
{
    /// <summary>
    /// 群公告设置
    /// </summary>
    public record AnnouncementSetting
    {

        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("target")]
        public string Target { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = "";

        /// <summary>
        /// 是否发送给新成员
        /// </summary>
        [JsonProperty("sendToNewMember")]
        public bool SendToNewMember { get; set; } = false;

        /// <summary>
        /// 是否置顶
        /// </summary>
        [JsonProperty("pinned")]
        public bool Pinned { get; set; } = false;

        /// <summary>
        /// 是否显示群成员修改群名片的引导
        /// </summary>
        [JsonProperty("showEditCard")]
        public bool ShowEditCard { get; set; } = false;

        /// <summary>
        /// 是否自动弹出
        /// </summary>
        [JsonProperty("showPopup")]
        public bool ShowPopup { get; set; } = false;

        /// <summary>
        /// 是否需要群成员确认
        /// </summary>
        [JsonProperty("requireConfirmation")]
        public bool RequireConfirmation { get; set; } = false;

        /// <summary>
        /// 公告图片url
        /// </summary>
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 公告图片本地路径
        /// </summary>
        [JsonProperty("imagePath")]
        public string ImagePath { get; set; }

        /// <summary>
        /// 公告图片base64编码
        /// </summary>
        [JsonProperty("imageBase64")]
        public string ImageBase64 { get; set; }

    }
}
