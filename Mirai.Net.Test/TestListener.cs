using System;using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Data.Events.Group;
using Mirai.Net.Listeners;
using Mirai.Net.Listeners.EventListeners;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListener : GroupEventListener
    {
        public TestListener()
        {
            MuteAll += args =>
            {
                Console.WriteLine(
                    $"{args.Operator.Name} {(args.Current ? "muted" : "unmuted")} {args.Operator.Group.Name}!");
            };
            
            AllowAnonymousChatChange += e =>
            {
                Console.WriteLine($"{e.Operator.Name} changed the group {e.Group.Id} anonymous chat status from {e.Origin} to {e.Current}");
            };
        }
    }
}