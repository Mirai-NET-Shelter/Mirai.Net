using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Messengers.Concrete
{
    public class RecallMessenger : MessengerBase
    {
        public override Task<MessageCallback> Send(params MessageBase[] message)
        {
            throw new System.NotImplementedException();
        }

        public override Task<MessageCallback> Quote(string messageId, params MessageBase[] message)
        {
            throw new System.NotImplementedException();
        }

        public string MessageId { get; set; }

        public RecallMessenger(string messageId = null)
        {
            MessageId = messageId;
        }

        public async Task Recall()
        {
            var url = $"{Bot.Session.GetUrl()}/recall";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                target = MessageId
            }.ToJson())).Content.ToJObject();
        }
    }
}