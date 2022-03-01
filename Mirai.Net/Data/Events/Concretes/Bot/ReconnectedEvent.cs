using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot;

public class ReconnectedEvent : EventBase
{
    [JsonProperty("qq")] public string QQ { get; private set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Reconnected;
}