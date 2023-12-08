using Mirai.Net.Data.Sessions;
using System.Threading.Tasks;

using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Managers;

using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

/// <summary>
/// 群消息接收器s
/// </summary>
public record GroupMessageReceiver : MessageReceiverBase
{
    /// <summary>
    /// 消息接收器类型
    /// </summary>
    [JsonProperty("sender")] public Member Sender { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonIgnore]
    public string GroupId => Sender.Group.Id;

    /// <summary>
    /// 群名称
    /// </summary>
    [JsonIgnore]
    public string GroupName => Sender.Group.Name;

    /// <summary>
    /// bot在群内的权限
    /// </summary>
    [JsonIgnore]
    public Permissions BotPermission => Sender.Group.Permission;

    /// <summary>
    /// 消息接收器类型
    /// </summary>
    public override MessageReceivers Type { get; set; } = MessageReceivers.Group;

    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="chain">消息链</param>
    /// <returns></returns>
    public override async Task<string> SendMessageAsync(MessageChain chain)
    {
        var payload = new
        {
            target = Sender.Group.Id,
            messageChain = chain
        };

        return await MessageManager.SendMessageAsync(HttpEndpoints.SendGroupMessage, payload);
    }
}