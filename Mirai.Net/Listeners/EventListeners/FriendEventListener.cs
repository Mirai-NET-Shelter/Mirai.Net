using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Friend;

namespace Mirai.Net.Listeners.EventListeners
{
    public abstract class FriendEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new List<EventType>
        {
            EventType.FriendRecallEvent,
            EventType.FriendNickChangedEvent,
            EventType.FriendInputStatusChangedEvent
        };

        public event Action<FriendInputStatusChangedEventArgs> InputChanged;
        public event Action<FriendNickChangedEventArgs> NickChanged;
        public event Action<FriendRecallEventArgs> Recall;
        
        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.FriendInputStatusChangedEvent:
                    InputChanged?.Invoke(args as FriendInputStatusChangedEventArgs);
                    break;
                case EventType.FriendNickChangedEvent:
                    NickChanged?.Invoke(args as FriendNickChangedEventArgs);
                    break;
                case EventType.FriendRecallEvent:
                    Recall?.Invoke(args as FriendRecallEventArgs);
                    break;
            }
        }
    }
}