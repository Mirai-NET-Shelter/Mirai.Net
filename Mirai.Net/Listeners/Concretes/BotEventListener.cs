using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;

namespace Mirai.Net.Listeners.Concretes
{
    public class BotEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new[]
        {
            EventType.BotOnlineEvent,
            EventType.BotOfflineEventActive,
            EventType.BotOfflineEventForce,
            EventType.BotOfflineEventDropped,
            EventType.BotReloginEvent,
        };

        public event Action<BotEventArgs> Online;
        public event Action<BotEventArgs> Offline;
        public event Action<BotEventArgs> OfflinePassive;
        public event Action<BotEventArgs> Dropped;
        public event Action<BotEventArgs> Relogin;

        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.BotOnlineEvent:
                    Online?.Invoke(args as BotEventArgs);
                    break;
                case EventType.BotOfflineEventActive:
                    Offline?.Invoke(args as BotEventArgs);
                    break;
                case EventType.BotOfflineEventForce:
                    OfflinePassive?.Invoke(args as BotEventArgs);
                    break;
                case EventType.BotOfflineEventDropped:
                    Dropped?.Invoke(args as BotEventArgs);
                    break;
                case EventType.BotReloginEvent:
                    Relogin?.Invoke(args as BotEventArgs);
                    break;
            }
        }
    }
}