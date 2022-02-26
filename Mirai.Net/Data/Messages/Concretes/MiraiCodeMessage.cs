using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

public class MiraiCodeMessage : MessageBase
{
    public override Messages Type { get; set; } = Messages.MiraiCode;

    /// <summary>
    /// MiraiCode码，请确保已经转义
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }

    public MiraiCodeMessage(string code)
    {
        Code = code;
    }

    public MiraiCodeMessage()
    {
    }
}