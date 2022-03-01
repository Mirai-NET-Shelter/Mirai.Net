using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot;

/// <summary>
/// Bot主动重新登录
/// </summary>
public class ReconnectedEvent : EventBase
{
    /// <summary>
    /// Bot的QQ号
    /// </summary>
    [JsonProperty("qq")] public string QQ { get; private set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Reconnected;
}