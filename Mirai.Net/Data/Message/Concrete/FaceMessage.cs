using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Concrete
{
    public class FaceMessage : MessageBase
    {
        /// <summary>
        /// QQ表情编号，可选，优先高于name
        /// </summary>
        [JsonProperty("faceId")]
        public string FaceId {get; set;}
        
        /// <summary>
        /// QQ表情拼音，可选
        /// </summary>
        [JsonProperty("name")]
        public string Name {get; set;}
        
        public override MessageType Type { get; init; } = MessageType.Face;
    }
}