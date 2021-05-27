using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class AtMessage : MessageBase
    {
        public override string Type { get; set; } = "At";
        
        [JsonProperty("target")]
        public string Target {get; set;}
        
        [JsonProperty("display")]
        public string Display {get; set;}

        public AtMessage(string target = null, string display = null)
        {
            Target = target;
            Display = display;
        }
    }
}