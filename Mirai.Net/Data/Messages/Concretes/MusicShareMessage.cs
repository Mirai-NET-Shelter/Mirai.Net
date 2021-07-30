using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes
{
    public class MusicShareMessage : MessageBase
    {
        public override Messages Type { get; set; } = Messages.MusicShare;

        [JsonProperty("kind")] public string Kind { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("summary")] public string Summary { get; set; }

        [JsonProperty("jumpUrl")] public string JumpUrl { get; set; }

        [JsonProperty("pictureUrl")] public string PictureUrl { get; set; }

        [JsonProperty("musicUrl")] public string MusicUrl { get; set; }

        [JsonProperty("brief")] public string Brief { get; set; }
    }
}