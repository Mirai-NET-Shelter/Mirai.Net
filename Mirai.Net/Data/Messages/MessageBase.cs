using System.Collections.Generic;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages
{
    public class MessageBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        [JsonProperty("type")]
        public virtual string Type { get; set; }

        public override string ToString()
        {
            return this.ToJson();
        }

        protected MessageBase()
        {
        }
    }
}