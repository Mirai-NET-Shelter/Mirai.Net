using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Listeners;
using Mirai.Net.Listeners.Concretes;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListener : FriendEventListener
    {
        protected override FriendEvent Events { get; set; }

        public TestListener()
        {
            Events = new FriendEvent
            {
                NickChanged = args =>
                {
                    Console.WriteLine(args.ToJsonString());
                }
            };
        }
    }
}