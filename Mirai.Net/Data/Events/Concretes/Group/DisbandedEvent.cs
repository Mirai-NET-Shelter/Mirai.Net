using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirai.Net.Data.Events.Concretes.Group
{

    /// <summary>
    /// Bot因群主解散群而退出群
    /// </summary>
    public record DisbandedEvent : EventBase
    {

        /// <summary>
        /// 事件类型
        /// </summary>
        public override Events Type { get; set; } = Events.Disbanded;

        /// <summary>
        ///     Bot所在被解散的群的信息
        /// </summary>
        [JsonProperty("group")]
        public Shared.Group Group { get; set; }

        /// <summary>
        ///     Bot离开群后获取操作人的 Member 对象
        /// </summary>
        [JsonProperty("operator")]
        public Shared.Member Operator { get; set; }

    }
}
