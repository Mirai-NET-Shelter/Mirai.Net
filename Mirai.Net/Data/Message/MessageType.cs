namespace Mirai.Net.Data.Message
{
    public enum MessageType
    {
        /// <summary>
        /// 群消息
        /// </summary>
        Group,
        /// <summary>
        /// 好友消息
        /// </summary>
        Friend,
        /// <summary>
        /// 群临时消息
        /// </summary>
        Temp,
        /// <summary>
        /// 陌生人消息
        /// </summary>
        Stranger,
        /// <summary>
        /// 其他客户端消息
        /// </summary>
        OtherClient
    }
}