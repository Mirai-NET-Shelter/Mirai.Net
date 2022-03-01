using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群员被解除禁言
/// </summary>
public class MemberUnmutedEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberUnmuted;

    /// <summary>
    /// 当事人
    /// </summary>
    [JsonProperty("Member")] public Member Member { get; set; }

    /// <summary>
    /// 解除禁言的人
    /// </summary>
    [JsonProperty("Operator")] public Member Operator { get; set; }
}