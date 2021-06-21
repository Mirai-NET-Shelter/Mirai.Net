using System;
using System.Collections.Generic;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Group;

namespace Mirai.Net.Listeners.EventListeners
{
    public class GroupEventListener : IEventListener
    {
        public IEnumerable<EventType> EventTypes { get; set; } = new[]
        {
            EventType.GroupRecallEvent,
            EventType.GroupNameChangeEvent,
            EventType.GroupEntranceAnnouncementChangeEvent,
            EventType.GroupMuteAllEvent,
            EventType.GroupAllowAnonymousChatEvent,
            EventType.GroupAllowConfessTalkEvent,
            EventType.GroupAllowMemberInviteEvent
        };

        #region Event definitions

        public event Action<GroupRecallEventArgs> MessageRecall;

        public event Action<GroupNameChangeEventArgs> NameChange;

        public event Action<GroupEntranceAnnouncementChangeEventArgs> EntranceAnnouncementChange;

        public event Action<GroupMuteAllEventArgs> MuteAll;

        public event Action<GroupAllowAnonymousChatEventArgs> AllowAnonymousChatChange;

        public event Action<GroupAllowConfessTalkEventArgs> AllowConfessTalkChange;

        public event Action<GroupAllowMemberInviteEventArgs> AllowMemberInviteChange;

        #endregion

        public void Execute(EventArgsBase args)
        {
            switch (args.Type)
            {
                case EventType.GroupRecallEvent:
                    MessageRecall?.Invoke(args as GroupRecallEventArgs);
                    break;
                case EventType.GroupNameChangeEvent: 
                    NameChange?.Invoke(args as GroupNameChangeEventArgs);
                    break;
                case EventType.GroupEntranceAnnouncementChangeEvent: 
                    EntranceAnnouncementChange?.Invoke(args as GroupEntranceAnnouncementChangeEventArgs);
                    break;
                case EventType.GroupMuteAllEvent: 
                    MuteAll?.Invoke(args as GroupMuteAllEventArgs);
                    break;
                case EventType.GroupAllowAnonymousChatEvent: 
                    AllowAnonymousChatChange?.Invoke(args as GroupAllowAnonymousChatEventArgs);
                    break;
                case EventType.GroupAllowConfessTalkEvent: 
                    AllowConfessTalkChange?.Invoke(args as GroupAllowConfessTalkEventArgs);
                    break;
                case EventType.GroupAllowMemberInviteEvent: 
                    AllowMemberInviteChange?.Invoke(args as GroupAllowMemberInviteEventArgs);
                    break;
            }
        }
    }
}