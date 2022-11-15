using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{

    /// <summary>
    /// 群同步消息接收器
    /// </summary>
    public record GroupSyncMessageReceiver : MessageReceiverBase
    {

        /// <summary>
        /// 消息接收器类型
        /// </summary>
        public override MessageReceivers Type { get; set; } = MessageReceivers.GroupSync;

        /// <summary>
        /// 群信息
        /// </summary>
        [JsonProperty("subject")] public Group Subject { get; set; }

    }
}
