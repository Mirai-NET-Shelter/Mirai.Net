using System;
using Mirai.Net.Utils.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events
{
    public class EventArgsBase
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public EventType Type {get; protected set; }

        public override string ToString()
        {
            return this.ToJsonString();
        }
    }

    public enum EventType
    {
        /// <summary>
        /// Bot登录成功
        /// </summary>
        BotOnlineEvent,
        
        /// <summary>
        /// Bot主动离线
        /// </summary>
        BotOfflineEventActive,
        
        /// <summary>
        /// Bot被挤下线
        /// </summary>
        BotOfflineEventForce,
        
        /// <summary>
        /// Bot被服务器断开或因网络问题而掉线
        /// </summary>
        BotOfflineEventDropped,
        
        /// <summary>
        /// Bot主动重新登录
        /// </summary>
        BotReloginEvent,
        
        /// <summary>
        /// 好友输入状态改变
        /// </summary>
        FriendInputStatusChangedEvent,
        
        /// <summary>
        /// 好友昵称改变
        /// </summary>
        FriendNickChangedEvent,
        
        /// <summary>
        /// Bot在群里的权限被改变. 操作人一定是群主
        /// </summary>
        BotGroupPermissionChangeEvent,
        
        /// <summary>
        /// Bot被禁言
        /// </summary>
        BotMuteEvent,
        
        /// <summary>
        /// Bot被取消禁言
        /// </summary>
        BotUnmuteEvent,
        
        /// <summary>
        /// Bot加入了一个新群
        /// </summary>
        BotJoinGroupEvent,
        
        /// <summary>
        /// Bot主动退出一个群
        /// </summary>
        BotLeaveEventActive,
        
        /// <summary>
        /// Bot被踢出一个群
        /// </summary>
        BotLeaveEventKick,
        
        /// <summary>
        /// 群消息撤回
        /// </summary>
        GroupRecallEvent,
        
        /// <summary>
        /// 好友消息撤回
        /// </summary>
        FriendRecallEvent,
        
        /// <summary>
        /// 某个群名改变
        /// </summary>
        GroupNameChangeEvent,
        
        /// <summary>
        /// 某群入群公告改变
        /// </summary>
        GroupEntranceAnnouncementChangeEvent,
        
        /// <summary>
        /// 全员禁言
        /// </summary>
        GroupMuteAllEvent,
        
        /// <summary>
        /// 匿名聊天
        /// </summary>
        GroupAllowAnonymousChatEvent,
        
        /// <summary>
        /// 坦白说
        /// </summary>
        GroupAllowConfessTalkEvent,
        
        /// <summary>
        /// 允许群员邀请好友加群
        /// </summary>
        GroupAllowMemberInviteEvent,
        
        /// <summary>
        /// 新人入群的事件
        /// </summary>
        MemberJoinEvent,
        
        /// <summary>
        /// 成员被踢出群（该成员不是Bot）
        /// </summary>
        MemberLeaveEventKick,
        
        /// <summary>
        /// 成员主动离群（该成员不是Bot）
        /// </summary>
        MemberLeaveEventQuit,
        
        /// <summary>
        /// 群名片改动
        /// </summary>
        MemberCardChangeEvent,
        
        /// <summary>
        /// 群头衔改动（只有群主有操作限权）
        /// </summary>
        MemberSpecialTitleChangeEvent,
        
        /// <summary>
        /// 成员权限改变的事件（该成员不是Bot）
        /// </summary>
        MemberPermissionChangeEvent,
        
        /// <summary>
        /// 群成员被禁言事件（该成员不是Bot）
        /// </summary>
        MemberMuteEvent,
        
        /// <summary>
        /// 群成员被取消禁言事件（该成员不是Bot）
        /// </summary>
        MemberUnmuteEvent,
        
        /// <summary>
        /// 群员称号改变
        /// </summary>
        MemberHonorChangeEvent,
        
        /// <summary>
        /// 添加好友申请
        /// </summary>
        NewFriendRequestEvent,
        
        /// <summary>
        /// 用户入群申请（Bot需要有管理员权限）
        /// </summary>
        MemberJoinRequestEvent,
        
        /// <summary>
        /// Bot被邀请入群申请
        /// </summary>
        BotInvitedJoinGroupRequestEvent
    }
}