using System;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Data.Events.Friend;
using Websocket.Client;

namespace Mirai.Net.Utils.Extensions
{
    /// <summary>
    /// 消息相关拓展封装
    /// </summary>
    public static class MessageExtensions
    {
        /// <summary>
        /// 判断websocket收到的消息是不是事件消息
        /// </summary>
        /// <returns></returns>
        public static bool IsEvent(this ResponseMessage message)
        {
            var json = message.Text.ToJObject();

            if (json.Fetch("data").ToJObject().ContainsKey("session"))
            {
                return false;
            }
            
            var type = json["data"].Fetch("type");

            return type.ToLower().Contains("event");
        }
        
        /// <summary>
        /// 根据传进来json，解析为EventArgsBase的type，再转换成具体的EventArgs
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static EventArgsBase ConvertToConcrete(this string data)
        {
            var args = data.ToEntity<EventArgsBase>();
            return args.Type switch
            {
                EventType.BotOnlineEvent => data.ToEntity<BotEventArgs>(),
                EventType.BotOfflineEventActive => data.ToEntity<BotEventArgs>(),
                EventType.BotOfflineEventForce => data.ToEntity<BotEventArgs>(),
                EventType.BotOfflineEventDropped => data.ToEntity<BotEventArgs>(),
                EventType.BotReloginEvent => data.ToEntity<BotEventArgs>(),
                EventType.FriendInputStatusChangedEvent => data.ToEntity<FriendInputStatusChangedEventArgs>(),
                EventType.FriendNickChangedEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotGroupPermissionChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotMuteEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotUnmuteEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotJoinGroupEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotLeaveEventActive => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotLeaveEventKick => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.GroupRecallEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.FriendRecallEvent => data.ToEntity<FriendRecallEventArgs>(),
                EventType.GroupNameChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.GroupEntranceAnnouncementChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.GroupMuteAllEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.GroupAllowAnonymousChatEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.GroupAllowConfessTalkEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.GroupAllowMemberInviteEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberJoinEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberLeaveEventKick => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberLeaveEventQuit => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberCardChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberSpecialTitleChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberPermissionChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberMuteEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberUnmuteEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberHonorChangeEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.NewFriendRequestEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.MemberJoinRequestEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                EventType.BotInvitedJoinGroupRequestEvent => data.ToEntity<FriendNickChangedEventArgs>(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}