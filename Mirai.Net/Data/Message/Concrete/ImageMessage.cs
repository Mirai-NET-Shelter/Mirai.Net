using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    /// <summary>
    /// 四个参数任选其一，出现多个参数时，按照imageId > url > path > base64的优先级
    /// </summary>
    public class ImageMessage : MessageBase
    {
        /// <summary>
        /// 图片的imageId，群图片与好友图片格式不同。不为空时将忽略url属性
        /// </summary>
        [JsonProperty("imageId")]
        public string ImageId {get; set;}
        
        /// <summary>
        /// 图片的URL，发送时可作网络图片的链接；接收时为腾讯图片服务器的链接，可用于图片下载
        /// </summary>
        [JsonProperty("url")]
        public string Url {get; set;}
        
        /// <summary>
        /// 图片的路径，发送本地图片，相对路径于plugins/MiraiAPIHTTP/images
        /// </summary>
        [JsonProperty("path")]
        public string Path {get; set;}
        
        /// <summary>
        /// 图片的 Base64 编码
        /// </summary>
        [JsonProperty("base64")]
        public string Base64 {get; set;}
    }
}