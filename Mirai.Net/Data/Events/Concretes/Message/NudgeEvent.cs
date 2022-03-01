using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.Message;

/// <summary>
/// 某人被戳了一戳
/// </summary>
public class NudgeEvent : EventBase
{
    /// <summary>
    /// 是谁戳的
    /// </summary>
    [JsonProperty("fromId")] public string FromId { get; set; }

    /// <summary>
    /// 谁被戳了
    /// </summary>
    [JsonProperty("target")] public string Target { get; set; }

    /// <summary>
    /// 怎么戳的
    /// </summary>
    [JsonProperty("action")] public string Action { get; set; }

    /// <summary>
    /// 自定义的怎么戳
    /// </summary>
    [JsonProperty("suffix")] public string Suffix { get; set; }

    /// <summary>
    /// 来源
    /// </summary>
    [JsonProperty("subject")] public NudgeSubject Subject { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.Nudged;

    /// <summary>
    /// 来源
    /// </summary>
    public class NudgeSubject
    {
        /// <summary>
        /// 来源的QQ号（好友）或群号
        /// </summary>
        [JsonProperty("id")] public string Id { get; set; }

        /// <summary>
        /// 来源的类型，"Friend"或"Group"
        /// </summary>
        [JsonProperty("kind")] public string Kind { get; set; }
    }
}