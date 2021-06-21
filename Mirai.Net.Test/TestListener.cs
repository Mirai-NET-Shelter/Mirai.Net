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
        public TestListener()
        {
            NickChanged += args =>
            {
                Console.WriteLine(args.ToJsonString());
            };
        }
    }
}