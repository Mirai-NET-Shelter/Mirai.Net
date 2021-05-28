using System;
using Mirai.Net.Data.Bot.Events.Concrete.Args;
using Mirai.Net.Utilities.Extensions;

// ReSharper disable once CheckNamespace
namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<BotMutedEventArgs> BotMuted;
        public static event Action<BotOnlineEventArgs> BotOnline;
        public static event Action<BotOfflineActiveEventArgs> BotOfflineActive;
        public static event Action<BotOfflinePassiveEventArgs> BotOfflinePassive;
        public static event Action<BotDroppedEventArgs> BotDropped;
        public static event Action<BotReloginEventArgs> BotRelogin;
        public static event Action<BotPermissionChangedEventArgs> BotPermissionChanged;
        public static event Action<BotUnmutedEventArgs> BotUnmuted;
        public static event Action<BotJoinedGroupEventArgs> BotJoinedGroup;
        public static event Action<BotLeftGroupActiveEventArgs> BotLeftGroupActive;
        public static event Action<BotKickedEventArgs> BotKicked;

        private static void MatchEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "BotMuteEvent":
                    BotMuted?.Invoke(data.ToObject<BotMutedEventArgs>());
                    break;
                case "BotOnlineEvent":
                    BotOnline?.Invoke(data.ToObject<BotOnlineEventArgs>());
                    break;
                case "BotOfflineEventActive":
                    BotOfflineActive?.Invoke(data.ToObject<BotOfflineActiveEventArgs>());
                    break;
                case "BotOfflineEventForce":
                    BotOfflinePassive?.Invoke(data.ToObject<BotOfflinePassiveEventArgs>());
                    break;
                case "BotOfflineEventDropped":
                    BotDropped?.Invoke(data.ToObject<BotDroppedEventArgs>());
                    break;
                case "BotReloginEvent":
                    BotRelogin?.Invoke(data.ToObject<BotReloginEventArgs>());
                    break;
                case "BotGroupPermissionChangeEvent":
                    BotPermissionChanged?.Invoke(data.ToObject<BotPermissionChangedEventArgs>());
                    break;
                case "BotUnmuteEvent":
                    BotUnmuted?.Invoke(data.ToObject<BotUnmutedEventArgs>());
                    break;
                case "BotJoinGroupEvent":
                    BotJoinedGroup?.Invoke(data.ToObject<BotJoinedGroupEventArgs>());
                    break;
                case "BotLeaveEventActive":
                    BotLeftGroupActive?.Invoke(data.ToObject<BotLeftGroupActiveEventArgs>());
                    break;
                case "BotLeaveEventKick":
                    BotKicked?.Invoke(data.ToObject<BotKickedEventArgs>());
                    break;
            }
        }
    }
}