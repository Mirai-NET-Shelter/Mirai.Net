namespace Mirai.Net.Data.Events.Concretes.Group;

public class GroupNameChangedEvent : GroupSettingChangedEventBase<string>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupNameChanged;
}