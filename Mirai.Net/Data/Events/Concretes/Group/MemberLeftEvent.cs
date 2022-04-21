using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群成员离开群
/// </summary>
public record MemberLeftEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberLeft;

    /// <summary>
    /// 当事人
    /// </summary>
    [JsonProperty("member")] public Member Member { get; set; }
}