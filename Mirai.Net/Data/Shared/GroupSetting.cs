using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared
{
    public class GroupSetting
    {
        /// <summary>
        ///     群名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     群公告
        /// </summary>
        [JsonProperty("announcement")]
        public string Announcement { get; set; }

        /// <summary>
        ///     坦白说
        /// </summary>
        [JsonProperty("confessTalk")]
        public bool ConfessTalk { get; set; }

        /// <summary>
        ///     成员邀请
        /// </summary>
        [JsonProperty("allowMemberInvite")]
        public bool AllowMemberInvite { get; set; }

        /// <summary>
        ///     自动通过入群申请
        /// </summary>
        [JsonProperty("autoApprove")]
        public bool AutoApprove { get; set; }

        /// <summary>
        ///     匿名聊天
        /// </summary>
        [JsonProperty("anonymousChat")]
        public bool AnonymousChat { get; set; }
    }
}