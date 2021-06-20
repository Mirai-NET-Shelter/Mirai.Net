using System;
using Mirai.Net.Data.Events;
using Mirai.Net.Listeners;

namespace Mirai.Net.Test
{
    public class TestListener : IEventListener
    {
        public EventType EventType { get; set; } = EventType.GroupMuteAllEvent;
        public void Execute(EventArgsBase args)
        {
            Console.WriteLine(args.Type);
        }
    }
}