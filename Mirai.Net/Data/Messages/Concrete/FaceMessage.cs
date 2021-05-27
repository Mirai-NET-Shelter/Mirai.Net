using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class FaceMessage : MessageBase
    {
        public override string Type { get; set; } = "Face";
        
        [JsonProperty("faceId")]
        public string FaceId {get; set;}
        
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