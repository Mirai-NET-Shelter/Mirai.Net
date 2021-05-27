using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class FileMessage : MessageBase
    {
        public override string Type { get; set; } = "File";
        
        [JsonProperty("id")]
        public string Id {get; set;}
        
        [JsonProperty("internalId")]
        public string InternalId {get; set;}
        
        [JsonProperty("name")]
        public string Name {get; set;}
        
        [JsonProperty("size")]
        public string Size {get; set;}

        public FileMessage(string id = null, string internalId = null, string name = null, string size = null)
        {
            Id = id;
            InternalId = internalId;
            Name = name;
            Size = size;
        }
    }
}