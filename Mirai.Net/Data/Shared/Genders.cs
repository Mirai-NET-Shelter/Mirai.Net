using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 发送者的性别
/// </summary>
public enum Genders
{
    /// <summary>
    /// 男性
    /// </summary>
    [EnumMember(Value = "MALE")] [Description("MALE")]
    Male,

    /// <summary>
    /// 女性
    /// </summary>
    [EnumMember(Value = "FEMALE")] [Description("FEMALE")]
    Female,

    /// <summary>
    /// 未知
    /// </summary>
    [EnumMember(Value = "UNKNOWN")] [Description("UNKNOWN")]
    Unknown
}