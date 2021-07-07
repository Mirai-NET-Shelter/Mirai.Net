using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Group
{
    public class GroupRecallEventArgs : EventArgsBase
    {
        /// <summary>
        /// 原消息发送者的QQ号
        /// </summary>
        [JsonProperty("authorId")]
        public string AuthorId {get; set;}
        
        /// <summary>
        /// 消息id
        /// </summary>
        [JsonProperty("messageId")]
        public string MessageId {get; set;}
        
        /// <summary>
        /// 撤回时间戳
        /// </summary>
        [JsonProperty("time")]
        public string Time {get; set;}
        
        /// <summary>
        /// 产生此事件的群
        /// </summary>
        [JsonProperty("group")]
        public Contact.Group Group {get; set;}
        
        /// <summary>
        /// 操作者
        /// </summary>
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }

    /// <summary>
    /// 请不要使用此对象
    /// origin, current, group, operator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GroupSettingChangeEventArgs<T> : EventArgsBase
    {
        /// <summary>
        /// 原来的
        /// </summary>
        [JsonProperty("origin")]
        public T Origin {get; set;}
        
        /// <summary>
        /// 目前的
        /// </summary>
        [JsonProperty("current")]
        public T Current {get; set;}
        
        /// <summary>
        /// 产生此事件的群
        /// </summary>
        [JsonProperty("group")]
        public Contact.Group Group {get; set;}
        
        /// <summary>
        /// 操作者
        /// </summary>
        [JsonProperty("operator")]
        public GroupMember Operator {get; set;}
    }
    
    public class GroupNameChangeEventArgs : GroupSettingChangeEventArgs<string> { }

    public class GroupEntranceAnnouncementChangeEventArgs : GroupSettingChangeEventArgs<string> { }

    public class GroupMuteAllEventArgs : GroupSettingChangeEventArgs<bool> { }
    
    public class GroupAllowAnonymousChatEventArgs : GroupSettingChangeEventArgs<bool>{}
    
    public class GroupAllowConfessTalkEventArgs : GroupSettingChangeEventArgs<bool>{}
    
    public class GroupAllowMemberInviteEventArgs : GroupSettingChangeEventArgs<bool>{}
}