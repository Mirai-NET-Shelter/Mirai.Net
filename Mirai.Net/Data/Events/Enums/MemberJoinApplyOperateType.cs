using System.Runtime.Serialization;

namespace Mirai.Net.Data.Events.Enums
{
    public enum MemberJoinApplyOperateType
    {
        [EnumMember(Value = "0")]
        Accept,
        [EnumMember(Value = "1")]
        Reject,
        [EnumMember(Value = "2")]
        Ignore,
        [EnumMember(Value = "3")]
        RejectAndBlock,
        [EnumMember(Value = "4")]
        IgnoreAndBlock
    }
}