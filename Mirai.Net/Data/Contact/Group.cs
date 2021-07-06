﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Contact
{
    public class Group
    {
        /// <summary>
        /// 群号
        /// </summary>
        [JsonProperty("id")]
        public string Id {get; set;}
        
        /// <summary>
        /// 群名称
        /// </summary>
        [JsonProperty("name")]
        public string Name {get; set;}
        
        /// <summary>
        /// 权限类型
        /// </summary>
        [JsonProperty("permission")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupPermission Permission {get; set;}
    }

    public class GroupActionOperator
    {
        /// <summary>
        /// 操作者的QQ号
        /// </summary>
        [JsonProperty("id")]
        public string Id {get; set;}
        
        /// <summary>
        /// 操作者的群名片
        /// </summary>
        [JsonProperty("memberName")]
        public string Name {get; set;}
        
        /// <summary>
        /// 操作者在群中的权限
        /// </summary>
        [JsonProperty("permission")]
        [JsonConverter(typeof(StringEnumConverter))]
        public GroupPermission Permission {get; set;}

        /// <summary>
        /// 操作者的群头衔
        /// </summary>
        [JsonProperty("specialTitle")]
        public string SpecialTitle {get; set;}
        
        /// <summary>
        /// 加入时间戳
        /// </summary>
        [JsonProperty("joinTimestamp")]
        public string JoinTime {get; set;}
        
        /// <summary>
        /// 最后发言时间戳
        /// </summary>
        [JsonProperty("lastSpeakTimestamp")]
        public string LastSpeakTime {get; set;}
        
        /// <summary>
        /// 禁言时间还剩余
        /// </summary>
        [JsonProperty("muteTimeRemaining")]
        public string MuteTimeRemaining {get; set;}
        
        /// <summary>
        /// 产生此操作的群
        /// </summary>
        [JsonProperty("group")]
        public Group Group {get; set;}
    }

    public enum GroupPermission
    {
        [EnumMember(Value = "OWNER")]
        Owner,
        [EnumMember(Value = "ADMINISTRATOR")]
        Administrator,
        [EnumMember(Value = "MEMBER")]
        Member
    }
}