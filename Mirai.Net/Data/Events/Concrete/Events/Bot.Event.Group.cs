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
                
            }
        }
    }
}