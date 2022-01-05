using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers;

public class StrangerMessageReceiver : MessageReceiverBase
{
    public override MessageReceivers Type { get; set; } = MessageReceivers.Stranger;

    [JsonProperty("sender")] public Friend Sender { get; set; }
    
    /// <summary>
    /// 昵称
    /// </summary>
    public string Name => Sender.NickName;

    /// <summary>
    /// 备注
    /// </summary>
    public string Remark => Sender.Remark;

    /// <summary>
    /// QQ号
    /// </summary>
    public string Id => Sender.Id;
}