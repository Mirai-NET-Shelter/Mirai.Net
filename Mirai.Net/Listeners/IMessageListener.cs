using System.Collections.Generic;
using Mirai.Net.Data.Message;

namespace Mirai.Net.Listeners
{
    public interface IMessageListener
    {
        public IEnumerable<MessageType> Executors { get; init; }

        public void Execute(MessageArgs args);
    }
}