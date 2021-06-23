using System;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Apply;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Data.Events.Group;
using Mirai.Net.Data.Message;
using Mirai.Net.Data.Message.Args;
using Mirai.Net.Data.Message.Concrete;
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
            var re = type.ToLower().Contains("event");
                
            return re;
        }
        
        public static bool IsMessage(this ResponseMessage message)
        {
            var json = message.Text.ToJObject();

            if (json.Fetch("data").ToJObject().ContainsKey("session"))
            {
                return false;
            }
            
            var type = json["data"].Fetch("type");
            var re = type.ToLower().Contains("message");
            
            return re;
        }

        /// <summary>
        /// 根据传进来json，解析为EventArgsBase的type，再转换成具体的EventArgs
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static EventArgsBase ConvertToConcreteEventArgs(this string data)
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
                EventType.BotGroupPermissionChangeEvent => data.ToEntity<BotGroupPermissionChangeEventArgs>(),
                EventType.BotMuteEvent => data.ToEntity<BotMuteEventArgs>(),
                EventType.BotUnmuteEvent => data.ToEntity<BotUnmuteEventArgs>(),
                EventType.BotJoinGroupEvent => data.ToEntity<BotJoinGroupEventArgs>(),
                EventType.BotLeaveEventActive => data.ToEntity<BotLeaveGroupEventArgs>(),
                EventType.BotLeaveEventKick => data.ToEntity<BotLeaveGroupKickEventArgs>(),
                EventType.GroupRecallEvent => data.ToEntity<GroupRecallEventArgs>(),
                EventType.FriendRecallEvent => data.ToEntity<FriendRecallEventArgs>(),
                EventType.GroupNameChangeEvent => data.ToEntity<GroupNameChangeEventArgs>(),
                EventType.GroupEntranceAnnouncementChangeEvent => data.ToEntity<GroupEntranceAnnouncementChangeEventArgs>(),
                EventType.GroupMuteAllEvent => data.ToEntity<GroupMuteAllEventArgs>(),
                EventType.GroupAllowAnonymousChatEvent => data.ToEntity<GroupAllowAnonymousChatEventArgs>(),
                EventType.GroupAllowConfessTalkEvent => data.ToEntity<GroupAllowConfessTalkEventArgs>(),
                EventType.GroupAllowMemberInviteEvent => data.ToEntity<GroupAllowMemberInviteEventArgs>(),
                EventType.MemberJoinEvent => data.ToEntity<MemberJoinEventArgs>(),
                EventType.MemberLeaveEventKick => data.ToEntity<MemberLeaveEventKickArgs>(),
                EventType.MemberLeaveEventQuit => data.ToEntity<MemberLeaveEventQuitArgs>(),
                EventType.MemberCardChangeEvent => data.ToEntity<MemberCardChangeEventArgs>(),
                EventType.MemberSpecialTitleChangeEvent => data.ToEntity<MemberSpecialTitleChangeEventArgs>(),
                EventType.MemberPermissionChangeEvent => data.ToEntity<MemberPermissionChangeEventArgs>(),
                EventType.MemberMuteEvent => data.ToEntity<MemberMuteEventArgs>(),
                EventType.MemberUnmuteEvent => data.ToEntity<BotUnmuteEventArgs>(),
                EventType.MemberHonorChangeEvent => data.ToEntity<MemberHonorChangeEventArgs>(),
                EventType.NewFriendRequestEvent => data.ToEntity<NewFriendRequestEventArgs>(),
                EventType.MemberJoinRequestEvent => data.ToEntity<MemberJoinRequestEventArgs>(),
                EventType.BotInvitedJoinGroupRequestEvent => data.ToEntity<BotInvitedJoinGroupRequestEvent>(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static MessageArgs ConvertToConcreteMessageArgs(this string data)
        {
            var args = data.ToEntity<MessageArgs>();

            return args.Type switch
            {
                MessageReceiveType.Group => data.ToEntity<GroupMessageArgs>(),
                MessageReceiveType.Friend => data.ToEntity<FriendMessageArgs>(),
                MessageReceiveType.Temp => data.ToEntity<TempMessageArgs>(),
                MessageReceiveType.Stranger => data.ToEntity<StrangerMessageArgs>(),
                MessageReceiveType.OtherClient => data.ToEntity<OtherClientMessageArgs>(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        public static MessageBase ConvertToConcreteMessage(this string node)
        {
            var args = node.ToEntity<MessageBase>();

            return args.Type switch
            {
                MessageType.Source => node.ToEntity<SourceMessage>(),
                MessageType.Quote => node.ToEntity<QuoteMessage>(),
                MessageType.At => node.ToEntity<AtMessage>(),
                MessageType.AtAll => node.ToEntity<AtAllMessage>(),
                MessageType.Face => node.ToEntity<FaceMessage>(),
                MessageType.Plain => node.ToEntity<PlainMessage>(),
                MessageType.Image => node.ToEntity<ImageMessage>(),
                MessageType.FlashImage => node.ToEntity<FlashImageMessage>(),
                MessageType.Voice => node.ToEntity<VoiceMessage>(),
                MessageType.Xml => node.ToEntity<XmlMessage>(),
                MessageType.Json => node.ToEntity<JsonMessage>(),
                MessageType.App => node.ToEntity<AppMessage>(),
                MessageType.Poke => node.ToEntity<PokeMessage>(),
                MessageType.Dice => node.ToEntity<DiceMessage>(),
                MessageType.MusicShare => node.ToEntity<MusicShareMessage>(),
                MessageType.Forward => node.ToEntity<ForwardMessage>(),
                MessageType.File => node.ToEntity<FileMessage>(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}