using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Shared
{
    public enum ImageUploadTargets
    {
        [Description("friend")] [EnumMember(Value = "friend")]
        Friend,

        [Description("group")] [EnumMember(Value = "group")]
        Group,

        [Description("temp")] [EnumMember(Value = "temp")]
        Temp
    }
}