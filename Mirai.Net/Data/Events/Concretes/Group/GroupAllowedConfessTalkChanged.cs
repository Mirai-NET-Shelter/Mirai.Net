namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群内是否允许坦白说的状态发生改变
/// </summary>
public record GroupAllowedConfessTalkChanged : GroupSettingChangedEventBase<bool>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupAllowedConfessTalk;
}