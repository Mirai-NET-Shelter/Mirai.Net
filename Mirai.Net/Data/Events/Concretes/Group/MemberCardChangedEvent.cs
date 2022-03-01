namespace Mirai.Net.Data.Events.Concretes.Group;

public class MemberCardChangedEvent : GroupMemberSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberCardChanged;
}