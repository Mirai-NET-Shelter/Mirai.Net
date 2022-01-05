using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

public class GroupMessageReceiver : MessageReceiverBase
{
    [JsonProperty("sender")] public Member Sender { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    public string Id => Sender.Group.Id;

    /// <summary>
    /// 群名称
    /// </summary>
    public string Name => Sender.Group.Name;

    /// <summary>
    /// bot在群内的权限
    /// </summary>
    public Permissions Permission => Sender.Group.Permission;

    public override MessageReceivers Type { get; set; } = MessageReceivers.Group;
}