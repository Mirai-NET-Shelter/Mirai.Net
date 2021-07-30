using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Messages
{
    public enum MessageReceivers
    {
        [Description("FriendMessage")] [EnumMember(Value = "FriendMessage")]
        Friend,

        [Description("GroupMessage")] [EnumMember(Value = "GroupMessage")]
        Group,

        [Description("TempMessage")] [EnumMember(Value = "TempMessage")]
        Temp,

        [Description("StrangerMessage")] [EnumMember(Value = "StrangerMessage")]
        Stranger,

        [Description("OtherClientMessage")] [EnumMember(Value = "OtherClientMessage")]
        OtherClient
    }
}