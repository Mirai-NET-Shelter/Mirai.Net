using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Bot;

/// <summary>
/// Bot被服务器断开或因网络问题而掉线
/// </summary>
public class DroppedEvent : EventBase
{
    /// <summary>
    /// Bot的QQ号
    /// </summary>
    [JsonProperty("qq")] public string QQ { get; private set; }
    
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Dropped;
}