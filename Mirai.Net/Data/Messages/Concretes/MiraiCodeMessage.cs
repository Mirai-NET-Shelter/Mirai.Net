using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

public class MiraiCodeMessage : MessageBase
{
    public override Messages Type { get; set; } = Messages.MiraiCode;

    private string _code;

    [JsonProperty("code")]
    public string Code
    {
        get => _code;
        set => _code = value;
    }
}