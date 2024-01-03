using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// Mirai码，
/// <a href="https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html#miraicode">看这里</a>
/// </summary>
public record MiraiCodeMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.MiraiCode;

    /// <summary>
    /// MiraiCode码，请确保已经转义
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }

    /// <summary>
    /// 带参数的构造器
    /// </summary>
    /// <param name="code"></param>
    public MiraiCodeMessage(string code)
    {
        Code = code;
    }

    /// <summary>
    /// 
    /// </summary>
    public MiraiCodeMessage()
    {
    }
}