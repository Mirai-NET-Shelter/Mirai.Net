namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 某人的群名片改变
/// </summary>
public class MemberCardChangedEvent : GroupMemberSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberCardChanged;
}