using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

public class MiraiCodeMessage : MessageBase
{
    public override Messages Type { get; set; }
    
    [JsonProperty("code")]
    public string Code {get; set;}
}