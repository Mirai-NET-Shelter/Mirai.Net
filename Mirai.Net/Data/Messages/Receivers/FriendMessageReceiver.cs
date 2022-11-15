using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

/// <summary>
/// 好友消息接收器
/// </summary>
public record FriendMessageReceiver : MessageReceiverBase
{
    /// <summary>
    /// 消息接收器类型
    /// </summary>
    public override MessageReceivers Type { get; set; } = MessageReceivers.Friend;

    /// <summary>
    /// 发送者，某好友
    /// </summary>
    [JsonProperty("sender")] public Friend Sender { get; set; }

    /// <summary>
    /// 好友昵称
    /// </summary>
    [JsonIgnore]
    public string FriendName => Sender.NickName;

    /// <summary>
    /// 好友备注
    /// </summary>
    [JsonIgnore]
    public string FriendRemark => Sender.Remark;

    /// <summary>
    /// 好友QQ号
    /// </summary>
    [JsonIgnore]
    public string FriendId => Sender.Id;
}