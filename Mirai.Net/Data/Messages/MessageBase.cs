using System.Collections.Generic;

namespace Mirai.Net.Data.Messages
{
    //TODO: add comment for concrete types
    public abstract class MessageBase
    {
        /// <summary>
        /// 类型
        /// </summary>
        public abstract string Type { get; set; }
    }
}