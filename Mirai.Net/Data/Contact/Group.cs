using System.Runtime.Serialization;
using Newtonsoft.Json;

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
        public GroupPermission Permission {get; set;}
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