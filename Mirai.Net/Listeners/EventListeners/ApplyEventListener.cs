using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Apply;
using Mirai.Net.Data.Events.Group;

namespace Mirai.Net.Listeners.EventListeners
{
    public class ApplyEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new[]
        {
            EventType.NewFriendRequestEvent,
            EventType.MemberJoinRequestEvent,
            EventType.BotInvitedJoinGroupRequestEvent
        };

        public event Action<NewFriendRequestEventArgs> NewFriendRequest;
        public event Action<MemberJoinRequestEventArgs> MemberJoinRequest;
        public event Action<BotInvitedJoinGroupRequestEvent> BotInvited; 
        
        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.NewFriendRequestEvent:
                    NewFriendRequest?.Invoke(args as NewFriendRequestEventArgs);
                    break;
                case EventType.MemberJoinRequestEvent:
                    MemberJoinRequest?.Invoke(args as MemberJoinRequestEventArgs);
                    break;
                case EventType.BotInvitedJoinGroupRequestEvent:
                    BotInvited?.Invoke(args as BotInvitedJoinGroupRequestEvent);
                    break;
            }
        }
    }
}