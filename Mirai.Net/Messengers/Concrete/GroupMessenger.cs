using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Messengers.Concrete
{
    public class GroupMessenger : MessengerBase
    {
        public string Group { get; set; }

        public GroupMessenger(string @group = null)
        {
            Group = @group;
        }

        public override async Task<MessageCallback> Send(params MessageBase[] message)
        {
            var url = $"{Bot.Session.GetUrl()}/sendGroupMessage";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                group = Group,
                messageChain = message
            }.ToJson())).Content.ToJObject();

            return result.ToObject<MessageCallback>();
        }
        
        public override async Task<MessageCallback> Quote(string messageId, params MessageBase[] messages)
        {
            var url = $"{Bot.Session.GetUrl()}/sendGroupMessage";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                group = Group,
                messageChain = messages,
                quote = messageId
            }.ToJson())).Content.ToJObject();

            return result.ToObject<MessageCallback>();
        }
    }
}