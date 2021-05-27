using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class FaceMessage : MessageBase
    {
        public override string Type { get; set; } = "Face";
        
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

        public FaceMessage(string faceIdOrName)
        {
            if (faceIdOrName.IsNumber())
            {
                FaceId = faceIdOrName;
            }
            else
            {
                Name = faceIdOrName;
            }
        }
    }
}