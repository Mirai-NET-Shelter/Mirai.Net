using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Contact
{
    /// <summary>
    /// 好友对象
    /// </summary>
    public class Friend
    {
        /// <summary>
        /// 好友的QQ号
        /// </summary>
        [JsonProperty("id")]
        public string Id {get; set;}
        
        /// <summary>
        /// 好友的昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName {get; set;}
        
        /// <summary>
        /// 你给好友的备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark {get; set;}
    }

    public enum NewFriendRequestOperate
    {
        /// <summary>
        /// 同意
        /// </summary>
        Approve = 0,
        
        /// <summary>
        /// 拒绝
        /// </summary>
        Reject = 1,
        
        /// <summary>
        /// 拒绝并拉黑
        /// </summary>
        RejectAndBlock = 2
    }
}