using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// Bot加入了一个新群
/// </summary>
public record JoinedEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Joined;

    /// <summary>
    ///     加入的新群信息
    /// </summary>
    [JsonProperty("group")]
    public Shared.Group Group { get; set; }
}