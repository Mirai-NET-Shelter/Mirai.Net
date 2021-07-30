using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{
    public class GroupMessageReceiver : MessageReceiverBase
    {
        [JsonProperty("sender")] public Member Sender { get; set; }

        public override MessageReceivers Type { get; set; } = MessageReceivers.Group;
    }
}