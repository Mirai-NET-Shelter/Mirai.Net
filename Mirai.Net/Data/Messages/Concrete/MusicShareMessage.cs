using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class MusicShareMessage : MessageBase
    {
        public override string Type { get; set; } = "MusicShare";
        
        /// <summary>
        /// 音乐应用类型，必须为NeteaseCloudMusic,QQMusic,MiguMusic
        /// </summary>
        [JsonProperty("kind")]
        public string Kind {get; set;}
        
        /// <summary>
        /// 消息卡片标题
        /// </summary>
        [JsonProperty("title")]
        public string Title {get; set;}
        
        /// <summary>
        /// 消息卡片内容
        /// </summary>
        [JsonProperty("summary")]
        public string Summary {get; set;}
        
        /// <summary>
        /// 点击卡片跳转网页 URL
        /// </summary>
        [JsonProperty("jumpUrl")]
        public string JumpUrl {get; set;}
        
        /// <summary>
        /// 消息卡片图片 URL
        /// </summary>
        [JsonProperty("pictureUrl")]
        public string PictureUrl {get; set;}
        
        /// <summary>
        /// 音乐文件 URL
        /// </summary>
        [JsonProperty("musicUrl")]
        public string MusicUrl {get; set;}
        
        /// <summary>
        /// 在消息列表显示，可选，默认为[分享]$title
        /// </summary>
        [JsonProperty("brief")]
        public string Brief {get; set;}
    }
}