using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Shared;

/// <summary>
/// 图片上传目标
/// </summary>
public enum ImageUploadTargets
{
    /// <summary>
    /// 好友
    /// </summary>
    [Description("friend")] [EnumMember(Value = "friend")]
    Friend,

    /// <summary>
    /// 群
    /// </summary>
    [Description("group")] [EnumMember(Value = "group")]
    Group,

    /// <summary>
    /// 临时消息
    /// </summary>
    [Description("temp")] [EnumMember(Value = "temp")]
    Temp
}