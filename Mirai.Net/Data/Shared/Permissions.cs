using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 群内权限
/// </summary>
public enum Permissions
{
    /// <summary>
    /// 群主
    /// </summary>
    [EnumMember(Value = "OWNER")]
    [Description("OWNER")]
    Owner,

    /// <summary>
    /// 管理员
    /// </summary>
    [EnumMember(Value = "ADMINISTRATOR")]
    [Description("ADMINISTRATOR")]
    Administrator,

    /// <summary>
    /// 群员
    /// </summary>
    [EnumMember(Value = "MEMBER")]
    [Description("MEMBER")]
    Member
}