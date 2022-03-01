namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群头衔改动（只有群主有操作限权）
/// </summary>
public class MemberTitleChangedEvent : GroupMemberSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberTitleChanged;
}