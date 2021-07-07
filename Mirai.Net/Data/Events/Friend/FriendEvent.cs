using System;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Friend
{
    /// <summary>
    /// 好友输入状态改变
    /// </summary>
    public class FriendInputStatusChangedEventArgs : EventArgsBase
    {
        /// <summary>
        /// 当前输出状态是否正在输入
        /// </summary>
        [JsonProperty("inputting")]
        public bool Inputting {get; set;}
        
        /// <summary>
        /// 发出此事件的好友
        /// </summary>
        [JsonProperty("friend")]
        public Contact.Friend Friend {get; set;}
    }

    /// <summary>
    /// 好友昵称改变
    /// </summary>
    public class FriendNickChangedEventArgs : EventArgsBase
    {
        /// <summary>
        /// 发出此事件的好友
        /// </summary>
        [JsonProperty("friend")]
        public Contact.Friend Friend {get; set;}
        
        /// <summary>
        /// 原昵称
        /// </summary>
        [JsonProperty("from")]
        public string Origin {get; set;}
        
        /// <summary>
        /// 新昵称
        /// </summary>
        [JsonProperty("to")]
        public string New {get; set;}
    }

    /// <summary>
    /// 好友消息撤回
    /// </summary>
    public class FriendRecallEventArgs : EventArgsBase
    {
        /// <summary>
        /// 原消息发送者的QQ号
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId {get; set;}
        
        /// <summary>
        /// 原消息messageId
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId {get; set;}
        
        /// <summary>
        /// 原消息发送时间戳
        /// </summary>
        [JsonProperty("time")]
        public string Time {get; set;}
        
        /// <summary>
        /// 好友QQ号或BotQQ号
        /// </summary>
        [JsonProperty("operator")]
        public string Operator {get; set;}
    }
}