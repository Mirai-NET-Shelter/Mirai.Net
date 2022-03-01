using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

public class MemberUnmutedEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberUnmuted;

    [JsonProperty("Member")] public Member Member { get; set; }

    [JsonProperty("Operator")] public Member Operator { get; set; }
}