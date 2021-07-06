using System;using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Data.Events.Group;
using Mirai.Net.Data.Message;
using Mirai.Net.Data.Message.Concrete;
using Mirai.Net.Listeners;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListener : IMessageListener, IEventListener
    {
        private IEnumerable<EventType> _executors = new []
        {
            EventType.BotMuteEvent
        };

        public IEnumerable<MessageReceiveType> Executors { get; set; } = new[]
        {
            MessageReceiveType.Group
        };

        public void Execute(EventArgsBase args)
        {
            if (args is BotMuteEventArgs botMuteEventArgs)
            {
                Console.WriteLine($"{botMuteEventArgs.Operator.Name} muted me!");
            }
        }

        public void Execute(MessageArgs args)
        {
            if (args.Chain.ToList()[1] is PlainMessage p)
            {
                Console.WriteLine(p.Text);
            }
        }

        IEnumerable<EventType> IEventListener.Executors
        {
            get => _executors;
            set => _executors = value;
        }
    }
}