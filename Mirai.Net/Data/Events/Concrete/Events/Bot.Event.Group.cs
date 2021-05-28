using System;
using Mirai.Net.Data.Events.Concrete.Args.Group;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<GroupNameChangedEventArgs> GroupNameChanged;
        public static event Action<GroupEntranceAnnouncementChangedEventArgs> GroupEntranceAnnouncementChanged;
        public static event Action<GroupMuteAllChangedEventArgs> GroupMuteAllChanged;
        public static event Action<GroupAllowAnonymousChatChangedEventArgs> GroupAllowAnonymousChanged;
        public static event Action<GroupAllowConfessTalkChangedEventArgs> GroupAllowConfessTalkChanged;
        public static event Action<GroupAllowMemberInviteChangedEventArgs> GroupAllowMemberInviteChanged;
        public static event Action<GroupNewMemberJoinedEventArgs> GroupNewMemberJoined;
        public static event Action<GroupMemberKickedEventArgs> GroupMemberKicked;
        public static event Action<GroupMemberLeftGroupActiveEventArgs> GroupMemberLeftGroupActive;

        private static void MatchGroupEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "GroupNameChangeEvent":
                    GroupNameChanged?.Invoke(data.ToObject<GroupNameChangedEventArgs>());
                    break;
                case "GroupEntranceAnnouncementChangeEvent":
                    GroupEntranceAnnouncementChanged?.Invoke(data.ToObject<GroupEntranceAnnouncementChangedEventArgs>());
                    break;
                case "GroupMuteAllEvent":
                    GroupMuteAllChanged?.Invoke(data.ToObject<GroupMuteAllChangedEventArgs>());
                    break;
                case "GroupAllowAnonymousChatEvent":
                    GroupAllowAnonymousChanged?.Invoke(data.ToObject<GroupAllowAnonymousChatChangedEventArgs>());
                    break;
                case "GroupAllowConfessTalkEvent":
                    GroupAllowConfessTalkChanged?.Invoke(data.ToObject<GroupAllowConfessTalkChangedEventArgs>());
                    break;
                case "GroupAllowMemberInviteEvent":
                    GroupAllowMemberInviteChanged?.Invoke(data.ToObject<GroupAllowMemberInviteChangedEventArgs>());
                    break;
                case "MemberJoinEvent":
                    GroupNewMemberJoined?.Invoke(data.ToObject<GroupNewMemberJoinedEventArgs>());
                    break;
                case "MemberLeaveEventKick":
                    GroupMemberKicked?.Invoke(data.ToObject<GroupMemberKickedEventArgs>());
                    break;
                case "MemberLeaveEventQuit":
                    GroupMemberLeftGroupActive?.Invoke(data.ToObject<GroupMemberLeftGroupActiveEventArgs>());
                    break;
            }
        }
    }
}