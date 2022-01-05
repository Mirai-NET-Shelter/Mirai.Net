using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

public class FriendMessageReceiver : MessageReceiverBase
{
    public override MessageReceivers Type { get; set; } = MessageReceivers.Friend;

    [JsonProperty("sender")] public Friend Sender { get; set; }

    /// <summary>
    /// 好友昵称
    /// </summary>
    public string Name => Sender.NickName;

    /// <summary>
    /// 好友备注
    /// </summary>
    public string Remark => Sender.Remark;

    /// <summary>
    /// 好友QQ号
    /// </summary>
    public string Id => Sender.Id;
}