using Newtonsoft.Json;

namespace Mirai.Net.Data.Shared
{
    public class Friend
    {
        /// <summary>
        ///     好友的QQ号
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     好友的昵称
        /// </summary>
        [JsonProperty("nickname")]
        public string NickName { get; set; }

        /// <summary>
        ///     你给好友的备注
        /// </summary>
        [JsonProperty("remark")]
        public string Remark { get; set; }
    }
}