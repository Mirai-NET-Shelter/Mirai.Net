using System;
using Mirai.Net.Data.Messages.Enums;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class ImageMessage : MessageBase
    {
        public override string Type { get; set; } = "Image";
        
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
        /// 图片的路径，发送本地图片，相对路径于data/net.mamoe.mirai-api-http/images
        /// </summary>
        [JsonProperty("path")]
        public string Path {get; set;}

        public ImageMessage(string param, ImageMessageType type = ImageMessageType.Url)
        {
            _ = type switch
            {
                ImageMessageType.Id => ImageId = param,
                ImageMessageType.Url => Url = param,
                ImageMessageType.Path => Path = param,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}