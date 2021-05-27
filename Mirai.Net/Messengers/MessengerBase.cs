using Mirai.Net.Data.Messages;

namespace Mirai.Net.Messengers
{
    public abstract class MessengerBase
    {
        public abstract void Send(MessageBase message);
    }
}