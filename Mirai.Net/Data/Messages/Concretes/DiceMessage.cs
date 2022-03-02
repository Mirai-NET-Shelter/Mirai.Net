using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 骰子消息
/// </summary>
public class DiceMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Dice;

    /// <summary>
    ///     点数
    /// </summary>
    [JsonProperty("value")]
    public string Value { get; set; }
}