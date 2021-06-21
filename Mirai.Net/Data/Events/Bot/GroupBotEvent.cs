using Mirai.Net.Data.Contact;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Bot
{
    /// <summary>
    /// Bot在群里的权限被改变. 操作人一定是群主
    /// </summary>
    public class BotGroupPermissionChangeEventArgs : EventArgsBase
    {
        [JsonProperty("origin")]
        public GroupPermission Origin {get; set;}
        
        [JsonProperty("current")]
        public GroupPermission Current {get; set;}  
        
        [JsonProperty("group")]
        public Group Group {get; set;}
    }
}