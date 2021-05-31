using System;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Messengers.Concrete
{
    public class FriendMessenger : MessengerBase
    {
        public string Target { get; set; }

        public FriendMessenger(string target = null)
        {
            Target = target;
        }

        public override async Task<MessageCallback> Send(params MessageBase[] message)
        {
            var url = $"{Bot.Session.GetUrl()}/sendFriendMessage";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                target = Target,
                messageChain = message
            }.ToJson())).Content.ToJObject();

            return result.ToObject<MessageCallback>();
        }

        public override async Task<MessageCallback> Quote(string messageId, params MessageBase[] messages)
        {
            var url = $"{Bot.Session.GetUrl()}/sendFriendMessage";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                target = Target,
                messageChain = messages,
                quote = messageId
            }.ToJson())).Content.ToJObject();

            return result.ToObject<MessageCallback>();
        }
    }
}