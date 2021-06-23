using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Args
{
    public class FriendMessageArgs : MessageArgs
    {
        [JsonProperty("sender")]
        public Friend Sender {get; set;}
    }
}