using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Shared
{
    public class Group
    {
        /// <summary>
        ///     群号
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     群名称
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     权限类型
        /// </summary>
        [JsonProperty("permission")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Permissions Permission { get; set; }
    }
}