using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Listeners;

namespace Mirai.Net.Test
{
    public class TestListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new List<EventType>
        {
            EventType.GroupMuteAllEvent
        };

        public void Execute(EventArgsBase args)
        {
            Console.WriteLine(args.Type);
        }
    }
}