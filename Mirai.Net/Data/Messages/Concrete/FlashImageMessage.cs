using System;
using Mirai.Net.Data.Messages.Enums;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    /// <summary>
    /// 三个参数任选其一，出现多个参数时，按照imageId > url > path的优先级
    /// </summary>
    public class FlashImageMessage : MessageBase
    {
        public override string Type { get; set; } = "FlashImage";
        
        [JsonProperty("imageId")]
        public string ImageId {get; set;}
        
        [JsonProperty("url")]
        public string Url {get; set;}
        
        [JsonProperty("path")]
        public string Path {get; set;}
        
        public FlashImageMessage(string param, ImageMessageType type = ImageMessageType.Url)
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