using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Shared
{
    public enum Permissions
    {
        [EnumMember(Value = "OWNER")] [Description("OWNER")]
        Owner,

        [EnumMember(Value = "ADMINISTRATOR")] [Description("ADMINISTRATOR")]
        Administrator,

        [EnumMember(Value = "MEMBER")] [Description("MEMBER")]
        Member
    }
}