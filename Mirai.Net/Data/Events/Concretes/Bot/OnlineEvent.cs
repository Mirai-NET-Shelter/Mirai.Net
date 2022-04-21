using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot;

/// <summary>
///     Bot自身事件
/// </summary>
public record OnlineEvent : EventBase
{
    /// <summary>
    /// Bot的QQ号
    /// </summary>
    [JsonProperty("qq")] public string QQ { get; private set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Online;
}