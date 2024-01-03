using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 某群员被禁言
/// </summary>
public record MemberMutedEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberMuted;

    /// <summary>
    /// 禁言时长，单位为秒
    /// </summary>
    [JsonProperty("durationSeconds")] public int Period { get; set; }

    /// <summary>
    /// 当事人
    /// </summary>
    [JsonProperty("Member")] public Member Member { get; set; }

    /// <summary>
    /// 禁言者
    /// </summary>
    [JsonProperty("Operator")] public Member Operator { get; set; }
}