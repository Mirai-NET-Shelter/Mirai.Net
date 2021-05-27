using System.Threading.Tasks;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Messengers.Concrete
{
    public class GroupMessenger : MessengerBase
    {
        public override Task<MessageCallback> Send(params MessageBase[] message)
        {
            
        }

        public override Task<MessageCallback> Send(string messageId, params MessageBase[] message)
        {
            
        }
    }
}