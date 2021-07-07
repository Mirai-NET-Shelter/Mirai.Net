using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Message.Args
{
    public class GroupMessageArgs : MessageArgs
    {
        [JsonProperty("sender")]
        public GroupMember Sender {get; set;}
    }
}