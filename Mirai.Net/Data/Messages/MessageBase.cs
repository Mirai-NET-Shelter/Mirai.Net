using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages
{
    //TODO: add comment for concrete types
    public abstract class MessageBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        public abstract string Type { get; set; }
    }
}