using System;
using System.Collections.Generic;
using Mirai.Net.Data.Contact;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Apply;
using Mirai.Net.Listeners;
using Mirai.Net.Managers;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListenerEvent : IEventListener
    {
        public IEnumerable<EventType> Executors { get; set; } = new[]
        {
            EventType.NewFriendRequestEvent
        };
        
        public void Execute(EventArgsBase args, MiraiBot bot)
        {
            if (args is NewFriendRequestEventArgs fArgs)
            {
                Console.WriteLine($"Received new friend request: \n{fArgs}");

                var mar = new ContactManager(bot);

                mar.HandleFriendRequest(fArgs, NewFriendRequestOperate.Approve);
            }
        }
    }
}