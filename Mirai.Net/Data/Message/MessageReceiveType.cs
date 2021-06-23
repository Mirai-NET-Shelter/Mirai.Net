using System.Runtime.Serialization;
using Mirai.Net.Data.Contact;

namespace Mirai.Net.Data.Message
{
    public enum MessageReceiveType
    {
        /// <summary>
        /// 群消息
        /// </summary>
        [EnumMember(Value = "GroupMessage")]
        Group,

        /// <summary>
        /// 好友消息
        /// </summary>
        [EnumMember(Value = "FriendMessage")]
        Friend,

        /// <summary>
        /// 群临时消息
        /// </summary>
        [EnumMember(Value = "TempMessage")]
        Temp,

        /// <summary>
        /// 陌生人消息
        /// </summary>
        [EnumMember(Value = "StrangerMessage")]
        Stranger,

        /// <summary>
        /// 其他客户端消息
        /// </summary>
        [EnumMember(Value = "OtherClientMessage")]
        OtherClient
    }
}