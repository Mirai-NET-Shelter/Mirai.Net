using System.Threading.Tasks;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Messengers.Concrete
{
    public class RecallMessenger : MessengerBase
    {
        public override Task<MessageCallback> Send(params MessageBase[] message)
        {
            throw new System.NotImplementedException();
        }

        public override Task<MessageCallback> Send(string messageId, params MessageBase[] message)
        {
            throw new System.NotImplementedException();
        }
    }
}