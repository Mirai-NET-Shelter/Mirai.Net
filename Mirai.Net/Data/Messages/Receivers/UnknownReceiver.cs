using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

/// <summary>
/// 未知类型的消息接收器
/// </summary>
public record UnknownReceiver : MessageReceiverBase
{
    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public override MessageReceivers Type { get; set; } = MessageReceivers.Unknown;

    /// <summary>
    /// 收到的json
    /// </summary>
    [JsonIgnore]
    public string RawJson { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public UnknownReceiver()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawJson"></param>
    public UnknownReceiver(string rawJson)
    {
        RawJson = rawJson;
    }
}