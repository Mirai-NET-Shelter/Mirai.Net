using Mirai.Net.Data.Shared;

namespace Mirai.Net.Data.Events.Concretes.Group;

public class MemberPermissionChangedEvent : GroupMemberSettingChangedEventBase<Permissions>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberPermissionChanged;
}