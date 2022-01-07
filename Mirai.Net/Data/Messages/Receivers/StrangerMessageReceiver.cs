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
    [JsonIgnore]
    public string Name => Sender.NickName;

    /// <summary>
    /// 备注
    /// </summary>
    [JsonIgnore]
    public string Remark => Sender.Remark;

    /// <summary>
    /// QQ号
    /// </summary>
    [JsonIgnore]
    public string Id => Sender.Id;
}