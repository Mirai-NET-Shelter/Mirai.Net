namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群内是否允许群员邀请新成员的状态发生改变
/// </summary>
public record GroupAllowedMemberInviteEvent : GroupSettingChangedEventBase<bool>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupAllowedMemberInvite;
}