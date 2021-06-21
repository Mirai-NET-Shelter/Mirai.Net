using System.Runtime.Serialization;
using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Group
{
    public class MemberJoinEventArgs : EventArgsBase
    {
        [JsonProperty("member")]
        public GroupActionOperator Member {get; set;}
    }

    public class MemberLeaveEventKickArgs : EventArgsBase
    {
        [JsonProperty("member")]
        public GroupActionOperator Member {get; set;}
        
        [JsonProperty("operator")]
        public GroupActionOperator Operator {get; set;}
    }

    public class MemberLeaveEventQuitArgs : EventArgsBase
    {
        [JsonProperty("member")]
        public GroupActionOperator Member {get; set;}
    }

    /// <summary>
    /// 请不要使用此类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class GroupMemberSettingChangeEvent<T> : EventArgsBase
    {
        [JsonProperty("origin")]
        public T Origin {get; set;}
        
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
        [JsonProperty("member")]
        public GroupActionOperator Member {get; set;}
    }
    
    public class MemberCardChangeEventArgs : GroupMemberSettingChangeEvent<string>{}
    
    public class MemberSpecialTitleChangeEventArgs : GroupSettingChangeEventArgs<string> {}
    
    public class MemberPermissionChangeEvent : GroupMemberSettingChangeEvent<GroupPermission>{}

    public class MemberMuteEventArgs : EventArgsBase
    {
        [JsonProperty("durationSeconds")]
        public string Period {get; set;}
        
        [JsonProperty("Member")]
        public GroupActionOperator Member {get; set;}
        
        [JsonProperty("Operator")]
        public GroupActionOperator Operator {get; set;}
    }
    
    public class MemberUnmuteEventArgs : EventArgsBase
    {
        [JsonProperty("Member")]
        public GroupActionOperator Member {get; set;}
        
        [JsonProperty("Operator")]
        public GroupActionOperator Operator {get; set;}
    }

    public class MemberHonorChangeEventArgs : EventArgsBase
    {
        [JsonProperty("member")]
        public GroupActionOperator Member {get; set;}
        
        /// <summary>
        /// 获得还是失去称号
        /// </summary>
        [JsonProperty("action")]
        public MemberHonorAction Action {get; set;}
        
        /// <summary>
        /// 称号名称
        /// </summary>
        [JsonProperty("honor")]
        public string Honor {get; set;}
        
        public enum MemberHonorAction
        {
            [EnumMember(Value = "achieve")]
            Achieve,
            [EnumMember(Value = "lose")]
            Lose
        }
    }
}