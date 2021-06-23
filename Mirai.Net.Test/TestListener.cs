using System;using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Data.Events.Group;
using Mirai.Net.Listeners;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListener : IEventListener
    {
        public TestListener()
        {
            
        }

        public IEnumerable<EventType> EventTypes { get; set; }
        public void Execute(EventArgsBase args)
        {
            throw new NotImplementedException();
        }
    }
}