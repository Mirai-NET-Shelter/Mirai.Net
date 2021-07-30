using Mirai.Net.Data.Shared;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Receivers
{
    public class TempMessageReceiver : MessageReceiverBase
    {
        public override MessageReceivers Type { get; set; } = MessageReceivers.Temp;

        [JsonProperty("sender")] public Member Sender { get; set; }
    }
}