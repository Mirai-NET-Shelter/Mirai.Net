using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Listeners;
using Mirai.Net.Listeners.EventListeners;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListener : GroupBotEventListener
    {
        public TestListener()
        {
            Mute += args =>
            {
                Console.WriteLine($"{args.Operator.Name} muted me in {args.Operator.Group.Name}!");
            };
        }
    }
}