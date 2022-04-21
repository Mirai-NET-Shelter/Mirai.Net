using System.ComponentModel;
using System.Runtime.Serialization;
using Mirai.Net.Data.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群员称号改变
/// </summary>
public record MemberHonorChangedEvent : EventBase
{
    /// <summary>
    /// 改变类型
    /// </summary>
    public enum MemberHonorAction
    {
        /// <summary>
        /// 得到称号
        /// </summary>
        [EnumMember(Value = "achieve")] [Description("achieve")]
        Achieve,

        /// <summary>
        /// 失去称号
        /// </summary>
        [EnumMember(Value = "lose")] [Description("lose")]
        Lose
    }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberHonorChanged;

    /// <summary>
    /// 当事人
    /// </summary>
    [JsonProperty("member")] public Member Member { get; set; }

    /// <summary>
    ///     获得还是失去称号
    /// </summary>
    [JsonProperty("action")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MemberHonorAction Action { get; set; }

    /// <summary>
    ///     称号名称
    /// </summary>
    [JsonProperty("honor")]
    public string Honor { get; set; }
}