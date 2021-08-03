using System.ComponentModel;
using System.Runtime.Serialization;

namespace Mirai.Net.Data.Events
{
    public enum Events
    {
        /// <summary>
        ///     Bot登录成功
        /// </summary>
        [Description("BotOnlineEvent")] [EnumMember(Value = "BotOnlineEvent")]
        Online,

        /// <summary>
        ///     Bot主动离线
        /// </summary>
        [Description("BotOfflineEventActive")] [EnumMember(Value = "BotOfflineEventActive")]
        Offline,

        /// <summary>
        ///     Bot被挤下线
        /// </summary>
        [Description("BotOfflineEventForce")] [EnumMember(Value = "BotOfflineEventForce")]
        OfflineForce,

        /// <summary>
        ///     Bot被服务器断开或因网络问题而掉线
        /// </summary>
        [Description("BotOfflineEventDropped")] [EnumMember(Value = "BotOfflineEventDropped")]
        Dropped,

        /// <summary>
        ///     Bot主动重新登录
        /// </summary>
        [Description("BotReloginEvent")] [EnumMember(Value = "BotReloginEvent")]
        Reconnected,

        /// <summary>
        ///     好友输入状态改变
        /// </summary>
        [Description("FriendInputStatusChangedEvent")] [EnumMember(Value = "FriendInputStatusChangedEvent")]
        FriendInputStatusChanged,

        /// <summary>
        ///     好友昵称改变
        /// </summary>
        [Description("FriendNickChangedEvent")] [EnumMember(Value = "FriendNickChangedEvent")]
        FriendNickChanged,

        /// <summary>
        ///     Bot在群里的权限被改变. 操作人一定是群主
        /// </summary>
        [Description("BotGroupPermissionChangeEvent")] [EnumMember(Value = "BotGroupPermissionChangeEvent")]
        PermissionChanged,

        /// <summary>
        ///     Bot被禁言
        /// </summary>
        [Description("BotMuteEvent")] [EnumMember(Value = "BotMuteEvent")]
        Muted,

        /// <summary>
        ///     Bot被取消禁言
        /// </summary>
        [Description("BotUnmuteEvent")] [EnumMember(Value = "BotUnmuteEvent")]
        Unmuted,

        /// <summary>
        ///     Bot加入了一个新群
        /// </summary>
        [Description("BotJoinGroupEvent")] [EnumMember(Value = "BotJoinGroupEvent")]
        Joined,

        /// <summary>
        ///     Bot主动退出一个群
        /// </summary>
        [Description("BotLeaveEventActive")] [EnumMember(Value = "BotLeaveEventActive")]
        Left,

        /// <summary>
        ///     Bot被踢出一个群
        /// </summary>
        [Description("BotLeaveEventKick")] [EnumMember(Value = "BotLeaveEventKick")]
        Kicked,

        /// <summary>
        ///     群消息撤回
        /// </summary>
        [Description("GroupRecallEvent")] [EnumMember(Value = "GroupRecallEvent")]
        GroupMessageRecalled,

        /// <summary>
        ///     好友消息撤回
        /// </summary>
        [Description("FriendRecallEvent")] [EnumMember(Value = "FriendRecallEvent")]
        FriendRecalled,

        /// <summary>
        ///     某个群名改变
        /// </summary>
        [Description("GroupNameChangeEvent")] [EnumMember(Value = "GroupNameChangeEvent")]
        GroupNameChanged,

        /// <summary>
        ///     某群入群公告改变
        /// </summary>
        [Description("GroupEntranceAnnouncementChangeEvent")]
        [EnumMember(Value = "GroupEntranceAnnouncementChangeEvent")]
        GroupEntranceAnnouncementChanged,

        /// <summary>
        ///     全员禁言
        /// </summary>
        [Description("GroupMuteAllEvent")] [EnumMember(Value = "GroupMuteAllEvent")]
        GroupMutedAll,

        /// <summary>
        ///     匿名聊天
        /// </summary>
        [Description("GroupAllowAnonymousChatEvent")] [EnumMember(Value = "GroupAllowAnonymousChatEvent")]
        GroupAllowedAnonymousChat,

        /// <summary>
        ///     坦白说
        /// </summary>
        [Description("GroupAllowConfessTalkEvent")] [EnumMember(Value = "GroupAllowConfessTalkEvent")]
        GroupAllowedConfessTalk,

        /// <summary>
        ///     允许群员邀请好友加群
        /// </summary>
        [Description("GroupAllowMemberInviteEvent")] [EnumMember(Value = "GroupAllowMemberInviteEvent")]
        GroupAllowedMemberInvite,

        /// <summary>
        ///     新人入群的事件
        /// </summary>
        [Description("MemberJoinEvent")] [EnumMember(Value = "MemberJoinEvent")]
        MemberJoined,

        /// <summary>
        ///     成员被踢出群（该成员不是Bot）
        /// </summary>
        [Description("MemberLeaveEventKick")] [EnumMember(Value = "MemberLeaveEventKick")]
        MemberKicked,

        /// <summary>
        ///     成员主动离群（该成员不是Bot）
        /// </summary>
        [Description("MemberLeaveEventQuit")] [EnumMember(Value = "MemberLeaveEventQuit")]
        MemberLeft,

        /// <summary>
        ///     群名片改动
        /// </summary>
        [Description("MemberCardChangeEvent")] [EnumMember(Value = "MemberCardChangeEvent")]
        MemberCardChanged,

        /// <summary>
        ///     群头衔改动（只有群主有操作限权）
        /// </summary>
        [Description("MemberSpecialTitleChangeEvent")] [EnumMember(Value = "MemberSpecialTitleChangeEvent")]
        MemberTitleChanged,

        /// <summary>
        ///     成员权限改变的事件（该成员不是Bot）
        /// </summary>
        [Description("MemberPermissionChangeEvent")] [EnumMember(Value = "MemberPermissionChangeEvent")]
        MemberPermissionChanged,

        /// <summary>
        ///     群成员被禁言事件（该成员不是Bot）
        /// </summary>
        [Description("MemberMuteEvent")] [EnumMember(Value = "MemberMuteEvent")]
        MemberMuted,

        /// <summary>
        ///     群成员被取消禁言事件（该成员不是Bot）
        /// </summary>
        [Description("MemberUnmuteEvent")] [EnumMember(Value = "MemberUnmuteEvent")]
        MemberUnmuted,

        /// <summary>
        ///     群员称号改变
        /// </summary>
        [Description("MemberHonorChangeEvent")] [EnumMember(Value = "MemberHonorChangeEvent")]
        MemberHonorChanged,

        /// <summary>
        ///     添加好友申请
        /// </summary>
        [Description("NewFriendRequestEvent")] [EnumMember(Value = "NewFriendRequestEvent")]
        NewFriendRequested,

        /// <summary>
        ///     用户入群申请（Bot需要有管理员权限）
        /// </summary>
        [Description("MemberJoinRequestEvent")] [EnumMember(Value = "MemberJoinRequestEvent")]
        NewMemberRequested,

        /// <summary>
        ///     Bot被邀请入群申请
        /// </summary>
        [Description("BotInvitedJoinGroupRequestEvent")] [EnumMember(Value = "BotInvitedJoinGroupRequestEvent")]
        NewInvitationRequested,
        
        /// <summary>
        /// 戳一戳事件
        /// </summary>
        [Description("NudgeEvent")] [EnumMember(Value = "NudgeEvent")]
        Nudged
    }
}