using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes;

/// <summary>
/// 未知的事件
/// </summary>
public record UnknownEvent : EventBase
{
    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore] public override Events Type { get; set; } = Events.Unknown;

    /// <summary>
    /// 原json
    /// </summary>
    [JsonIgnore]
    public string RawJson { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public UnknownEvent()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="rawJson"></param>
    public UnknownEvent(string rawJson)
    {
        RawJson = rawJson;
    }
}