using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class FaceMessage : MessageBase
    {
        /// <summary>
        ///     QQ表情编号，可选，优先高于name
        /// </summary>
        [JsonProperty("faceId")]
        public string FaceId { get; set; }

        /// <summary>
        ///     QQ表情拼音，可选
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        public override Messages Type { get; set; } = Messages.Face;
    }
}