using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

public class UnmutedEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Unmuted;

    /// <summary>
    ///     取消禁言bot的操作者
    /// </summary>
    [JsonProperty("operator")]
    public Member Operator { get; set; }
}