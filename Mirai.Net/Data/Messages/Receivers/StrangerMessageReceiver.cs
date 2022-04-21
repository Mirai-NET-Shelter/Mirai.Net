using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

/// <summary>
/// 陌生人接收器
/// </summary>
public record StrangerMessageReceiver : MessageReceiverBase
{
    /// <summary>
    /// 消息接收器类型
    /// </summary>
    public override MessageReceivers Type { get; set; } = MessageReceivers.Stranger;

    /// <summary>
    /// 发送者
    /// </summary>
    [JsonProperty("sender")] public Friend Sender { get; set; }
    
    /// <summary>
    /// 昵称
    /// </summary>
    [JsonIgnore]
    public string StrangerName => Sender.NickName;

    /// <summary>
    /// QQ号
    /// </summary>
    [JsonIgnore]
    public string StrangerId => Sender.Id;
}