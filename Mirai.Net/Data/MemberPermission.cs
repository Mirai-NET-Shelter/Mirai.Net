using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mirai.Net.Data
{
    public enum MemberPermission
    {
        [EnumMember(Value = "MEMBER")]
        Member,
        [EnumMember(Value = "ADMINISTRATOR")]
        Administrator,
        [EnumMember(Value = "OWNER")]
        Owner
    }
}