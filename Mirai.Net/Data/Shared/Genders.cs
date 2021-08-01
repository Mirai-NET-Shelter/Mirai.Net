using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Shared
{
    public enum Genders
    {
        [EnumMember(Value = "MALE")] [Description("MALE")]
        Male,

        [EnumMember(Value = "FEMALE")] [Description("FEMALE")]
        Female,

        [EnumMember(Value = "UNKNOWN")] [Description("UNKNOWN")]
        Unknown
    }
}