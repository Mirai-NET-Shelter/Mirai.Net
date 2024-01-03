namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 某群开启/关闭了全员禁言
/// </summary>
public record GroupMutedAllEvent : GroupSettingChangedEventBase<bool>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupMutedAll;
}