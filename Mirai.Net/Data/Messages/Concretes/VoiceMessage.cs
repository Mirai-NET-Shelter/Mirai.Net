using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class VoiceMessage : MessageBase
    {
        /// <summary>
        ///     语音的voiceId，不为空时将忽略url属性
        /// </summary>
        [JsonProperty("voiceId")]
        public string VoiceId { get; set; }

        /// <summary>
        ///     语音的URL，发送时可作网络语音的链接；接收时为腾讯语音服务器的链接，可用于语音下载
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        ///     语音的路径，发送本地语音，相对路径于plugins/MiraiAPIHTTP/voices
        /// </summary>
        [JsonProperty("path")]
        public string Path { get; set; }

        /// <summary>
        ///     语音的 Base64 编码
        /// </summary>
        [JsonProperty("base64")]
        public string Base64 { get; set; }

        public override Messages Type { get; set; } = Messages.Voice;
    }
}