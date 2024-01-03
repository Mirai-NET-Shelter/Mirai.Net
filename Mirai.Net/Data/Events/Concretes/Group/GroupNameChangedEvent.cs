namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 某群的改了群名
/// </summary>
public record GroupNameChangedEvent : GroupSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupNameChanged;
}