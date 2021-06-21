using Mirai.Net.Data.Contact;
using Newtonsoft.Json;
//QQ群内有关bot的事件
namespace Mirai.Net.Data.Events.Bot
{
    /// <summary>
    /// Bot在群里的权限被改变. 操作人一定是群主
    /// </summary>
    public class BotGroupPermissionChangeEventArgs : EventArgsBase
    {
        [JsonProperty("origin")]
        public GroupPermission Origin {get; set;}
        
        [JsonProperty("current")]
        public GroupPermission Current {get; set;}  
        
        [JsonProperty("group")]
        public Contact.Group Group {get; set;}
    }

    public class BotMuteEventArgs : EventArgsBase
    {
        /// <summary>
        /// 被禁言的时间，单位：秒
        /// </summary>
        [JsonProperty("durationSeconds")]
        public string Period {get; set;}
        
        /// <summary>
        /// 禁言bot的操作者
        /// </summary>
        [JsonProperty("operator")]
        public GroupActionOperator Operator {get; set;}
    }

    public class BotUnmuteEventArgs : EventArgsBase
    {
        /// <summary>
        /// 取消禁言bot的操作者
        /// </summary>
        [JsonProperty("operator")]
        public GroupActionOperator Operator {get; set;}
    }

    public class BotJoinGroupEventArgs : EventArgsBase
    {
        /// <summary>
        /// 加入的新群信息
        /// </summary>
        [JsonProperty("group")]
        public Contact.Group Group {get; set;}
    }

    public class BotLeaveGroupEventArgs : EventArgsBase
    {
        /// <summary>
        /// 主动退出的群信息
        /// </summary>
        [JsonProperty("group")]
        public Contact.Group Group {get; set;}
    }

    public class BotLeaveGroupKickEventArgs : EventArgsBase
    {
        /// <summary>
        /// bot被踢的群信息
        /// </summary>
        [JsonProperty("group")]
        public Contact.Group Group {get; set;}
    }
}