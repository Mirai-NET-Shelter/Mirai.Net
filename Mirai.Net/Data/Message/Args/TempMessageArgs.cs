using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Args
{
    public class TempMessageArgs : MessageArgs
    {
        [JsonProperty("sender")]
        public GroupActionOperator Sender {get; set;}
    }
}