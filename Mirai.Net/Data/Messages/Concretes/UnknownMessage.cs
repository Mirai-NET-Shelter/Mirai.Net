using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 未知的（没有实现）的消息类型
/// </summary>
public record UnknownMessage : MessageBase
{
    /// <summary>
    /// 收到的json
    /// </summary>
    [JsonIgnore]
    public string RawJson { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawJson"></param>
    public UnknownMessage(string rawJson)
    {
        RawJson = rawJson;
    }

    /// <summary>
    /// 
    /// </summary>
    public UnknownMessage()
    {
    }
}