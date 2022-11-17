using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{

    /// <summary>
    /// 群临时消息同步消息接收器
    /// </summary>
    public record TempSyncMessageReceiver : MessageReceiverBase
    {

        /// <summary>
        /// 消息接收器类型
        /// </summary>
        public override MessageReceivers Type { get; set; } = MessageReceivers.TempSync;

        /// <summary>
        /// 目标群成员的信息
        /// </summary>
        [JsonProperty("subject")] public Member TargetMember { get; set; }

    }
}
