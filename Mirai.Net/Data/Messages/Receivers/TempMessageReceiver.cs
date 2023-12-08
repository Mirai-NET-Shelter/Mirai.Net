using Mirai.Net.Data.Sessions;
using System.Threading.Tasks;

using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Managers;

using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

/// <summary>
/// 临时消息接收器
/// </summary>
public record TempMessageReceiver : MessageReceiverBase
{
    /// <summary>
    /// 消息接收器类型
    /// </summary>
    public override MessageReceivers Type { get; set; } = MessageReceivers.Temp;

    /// <summary>
    /// 发送者
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
    /// 发送临时消息
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

        return await MessageManager.SendMessageAsync(HttpEndpoints.SendTempMessage, payload);
    }
}