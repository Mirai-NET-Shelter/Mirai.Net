using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concrete
{
    public class QuoteMessage : MessageBase
    {
        public override string Type { get; set; } = "Send";

        [JsonProperty("id")] 
        public string Id { get; set; }

        [JsonProperty("groupId")] 
        public string GroupId { get; set; }

        [JsonProperty("senderId")] 
        public string SenderId { get; set; }

        [JsonProperty("targetId")] 
        public string TargetId { get; set; }

        [JsonProperty("origin")] 
        public IEnumerable<MessageBase> Origin { get; set; }

        public QuoteMessage(string id = null, string groupId = null, string senderId = null, string targetId = null, IEnumerable<MessageBase> origin = null)
        {
            Id = id;
            GroupId = groupId;
            SenderId = senderId;
            TargetId = targetId;
            Origin = origin;
        }
    }
}