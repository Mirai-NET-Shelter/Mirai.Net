using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Friend;

namespace Mirai.Net.Listeners.Concretes
{
    public abstract class FriendEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new List<EventType>
        {
            EventType.FriendRecallEvent,
            EventType.FriendNickChangedEvent,
            EventType.FriendInputStatusChangedEvent
        };

        protected abstract FriendEvent Events { get; set; }
        
        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.FriendInputStatusChangedEvent:
                    Events.InputChanged?.Invoke(args as FriendInputStatusChangedEventArgs);
                    break;
                case EventType.FriendNickChangedEvent:
                    Events.NickChanged?.Invoke(args as FriendNickChangedEventArgs);
                    break;
                case EventType.FriendRecallEvent:
                    Events.Recall?.Invoke(args as FriendRecallEventArgs);
                    break;
            }
        }
    }
}