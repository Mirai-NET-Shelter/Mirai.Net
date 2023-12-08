using Mirai.Net.Data.Sessions;
using System.Threading.Tasks;

using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Managers;

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

    /// <summary>
    /// 发送好友消息
    /// </summary>
    /// <param name="chain">消息链</param>
    /// <returns></returns>
    public override async Task<string> SendMessageAsync(MessageChain chain)
    {
        var payload = new
        {
            target = Sender.Id,
            messageChain = chain
        };

        return await MessageManager.SendMessageAsync(HttpEndpoints.SendFriendMessage, payload);
    }
}