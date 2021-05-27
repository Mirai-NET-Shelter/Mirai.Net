using System.Threading.Tasks;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Messengers.Concrete
{
    public class TempMessenger : MessengerBase
    {
        public override Task<MessageCallback> Send(params MessageBase[] message)
        {
            
        }
    }
}