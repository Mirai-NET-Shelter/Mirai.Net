using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{
    public class StrangerMessageReceiver : MessageReceiverBase
    {
        public override MessageReceivers Type { get; set; } = MessageReceivers.Stranger;

        [JsonProperty("sender")] public Friend Sender { get; set; }
    }
}