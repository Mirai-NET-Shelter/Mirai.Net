using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{
    public class OtherClientMessageReceiver : MessageReceiverBase
    {
        public override MessageReceivers Type { get; set; } = MessageReceivers.OtherClient;

        [JsonProperty("sender")] public OtherClient Sender { get; set; }
    }
}