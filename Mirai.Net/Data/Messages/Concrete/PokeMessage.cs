using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class PokeMessage : MessageBase
    {
        public override string Type { get; set; } = "Poke";
        
        [JsonProperty("name")]
        public string Name {get; set;}

        public PokeMessage(string name = null)
        {
            Name = name;
        }
    }
}