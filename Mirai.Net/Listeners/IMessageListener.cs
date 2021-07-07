using System.Collections.Generic;
using Mirai.Net.Data.Message;
using Mirai.Net.Sessions;

namespace Mirai.Net.Listeners
{
    public interface IMessageListener
    {
        public IEnumerable<MessageReceiveType> Executors { get; set; }

        public void Execute(MessageArgs args, MiraiBot bot);
    }
}