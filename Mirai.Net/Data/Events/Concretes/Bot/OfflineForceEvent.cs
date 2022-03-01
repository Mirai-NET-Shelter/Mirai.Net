using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot;

/// <summary>
/// Bot被挤下线
/// </summary>
public class OfflineForceEvent : EventBase
{
    /// <summary>
    /// Bit的QQ号
    /// </summary>
    [JsonProperty("qq")] public string QQ { get; private set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.OfflineForce;
}