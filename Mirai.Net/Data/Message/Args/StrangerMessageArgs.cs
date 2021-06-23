using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Args
{
    public class StrangerMessageArgs : MessageArgs
    {
        [JsonProperty("sender")]
        public Friend Sender {get; set;}
    }
}