using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;

namespace Mirai.Net.Listeners.Concretes
{
    public abstract class GroupBotEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new[]
        {
            EventType.BotMuteEvent,
            EventType.BotUnmuteEvent,
            EventType.BotJoinGroupEvent,
            EventType.BotLeaveEventActive,
            EventType.BotLeaveEventKick,
            EventType.BotGroupPermissionChangeEvent
        };

        public event Action<BotGroupPermissionChangeEventArgs> PermissionChange; 
        public event Action<BotMuteEventArgs> Mute;
        public event Action<BotUnmuteEventArgs> Unmute;
        public event Action<BotJoinGroupEventArgs> JoinNewGroup;
        public event Action<BotLeaveGroupEventArgs> Leave;
        public event Action<BotLeaveGroupKickEventArgs> Kick; 
        
        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.BotGroupPermissionChangeEvent:
                    PermissionChange?.Invoke(args as BotGroupPermissionChangeEventArgs);
                    break;
                case EventType.BotMuteEvent:
                    Mute?.Invoke(args as BotMuteEventArgs);
                    break;
                case EventType.BotUnmuteEvent:
                    Unmute?.Invoke(args as BotUnmuteEventArgs);
                    break;
                case EventType.BotJoinGroupEvent:
                    JoinNewGroup?.Invoke(args as BotJoinGroupEventArgs);
                    break;
                case EventType.BotLeaveEventActive:
                    Leave?.Invoke(args as BotLeaveGroupEventArgs);
                    break;
                case EventType.BotLeaveEventKick:
                    Kick?.Invoke(args as BotLeaveGroupKickEventArgs);
                    break;
            }
        }
    }
}