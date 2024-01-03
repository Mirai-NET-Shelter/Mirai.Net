using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Request;

/// <summary>
/// 请求事件基类
/// </summary>
public record class RequestedEventBase : EventBase
{
    /// <summary>
    /// 事件id
    /// </summary>
    [JsonProperty("eventId")] public string EventId { get; set; }

    /// <summary>
    /// 来自谁
    /// </summary>
    [JsonProperty("fromId")] public string FromId { get; set; }

    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("groupId")] public string GroupId { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    [JsonProperty("nick")] public string Nick { get; set; }

    /// <summary>
    /// 附加消息
    /// </summary>
    [JsonProperty("message")] public string Message { get; set; }
}