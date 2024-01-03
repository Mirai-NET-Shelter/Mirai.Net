using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// Bot主动离开了某群
/// </summary>
public record LeftEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Left;

    /// <summary>
    ///     退出的群信息
    /// </summary>
    [JsonProperty("group")]
    public Shared.Group Group { get; set; }
}