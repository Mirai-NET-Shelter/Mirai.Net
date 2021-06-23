using System.Collections.Generic;
using Mirai.Net.Data.Message;

namespace Mirai.Net.Listeners
{
    public interface IMessageListener : IListener<MessageType, MessageArgs>
    {
    }
}