using Mirai.Net.Data.Shared;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 某群员权限改变，操作者一定是群主
/// </summary>
public record MemberPermissionChangedEvent : GroupMemberSettingChangedEventBase<Permissions>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.MemberPermissionChanged;
}