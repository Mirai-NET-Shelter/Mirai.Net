using System.Threading.Tasks;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Messengers
{
    public abstract class MessengerBase
    {
        public abstract Task<MessageCallback> Send(params MessageBase[] message);
        public abstract Task<MessageCallback> Send(string messageId, params MessageBase[] message);
    }
}