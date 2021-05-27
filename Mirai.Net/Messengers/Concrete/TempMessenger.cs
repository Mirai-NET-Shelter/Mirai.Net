using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Messengers.Concrete
{
    public class TempMessenger : MessengerBase
    {
        public string QQ { get; set; }
        public string Group { get; set; }

        public TempMessenger(string qq = null, string @group = null)
        {
            QQ = qq;
            Group = @group;
        }

        public override async Task<MessageCallback> Send(params MessageBase[] message)
        {
            var url = $"{Bot.Session.GetUrl()}/sendTempMessage";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                qq = QQ,
                group = Group,
                messageChain = message
            }.ToJson())).Content.ToJObject();

            return result.ToObject<MessageCallback>();
        }
        
        public async Task<MessageCallback> Send(string messageId, params MessageBase[] messages)
        {
            var url = $"{Bot.Session.GetUrl()}/sendTempMessage";

            var result = (await HttpUtility.Post(url, new
            {
                sessionKey = Bot.Session.SessionKey,
                qq = QQ,
                group = Group,
                messageChain = messages,
                quote = messageId
            }.ToJson())).Content.ToJObject();

            return result.ToObject<MessageCallback>();
        }
    }
}