using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Group;

namespace Mirai.Net.Listeners.EventListeners
{
    public class GroupMemberEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new[]
        {
            EventType.MemberJoinEvent,
            EventType.MemberLeaveEventKick,
            EventType.MemberLeaveEventQuit,
            EventType.MemberCardChangeEvent,
            EventType.MemberSpecialTitleChangeEvent,
            EventType.MemberPermissionChangeEvent,
            EventType.MemberMuteEvent,
            EventType.MemberUnmuteEvent,
            EventType.MemberHonorChangeEvent
        };

        #region Event definitions

        public event Action<MemberJoinEventArgs> MemberJoin;
        public event Action<MemberLeaveEventKickArgs> MemberKick;
        public event Action<MemberLeaveEventQuitArgs> MemberQuit;
        public event Action<MemberCardChangeEventArgs> MemberCardChange;
        public event Action<MemberPermissionChangeEventArgs> MemberPermissionChange;
        public event Action<MemberSpecialTitleChangeEventArgs> MemberSpecialTitleChange;
        public event Action<MemberMuteEventArgs> MemberMute;
        public event Action<MemberUnmuteEventArgs> MemberUnmute;
        public event Action<MemberHonorChangeEventArgs> MemberHonorChange; 

        #endregion
        
        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.MemberJoinEvent:
                    MemberJoin?.Invoke(args as MemberJoinEventArgs);
                    break;
                case EventType.MemberLeaveEventKick:
                    MemberKick?.Invoke(args as MemberLeaveEventKickArgs);
                    break;
                case EventType.MemberLeaveEventQuit:
                    MemberQuit?.Invoke(args as MemberLeaveEventQuitArgs);
                    break;
                case EventType.MemberCardChangeEvent:
                    MemberCardChange?.Invoke(args as MemberCardChangeEventArgs);
                    break;
                case EventType.MemberSpecialTitleChangeEvent:
                    MemberSpecialTitleChange?.Invoke(args as MemberSpecialTitleChangeEventArgs);
                    break;
                case EventType.MemberPermissionChangeEvent:
                    MemberPermissionChange?.Invoke(args as MemberPermissionChangeEventArgs);
                    break;
                case EventType.MemberMuteEvent:
                    MemberMute?.Invoke(args as MemberMuteEventArgs);
                    break;
                case EventType.MemberUnmuteEvent:
                    MemberUnmute?.Invoke(args as MemberUnmuteEventArgs);
                    break;
                case EventType.MemberHonorChangeEvent:
                    MemberHonorChange?.Invoke(args as MemberHonorChangeEventArgs);
                    break;
            }
        }
    }
}