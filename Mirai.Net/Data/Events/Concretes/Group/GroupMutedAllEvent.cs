namespace Mirai.Net.Data.Events.Concretes.Group;

public class GroupMutedAllEvent : GroupSettingChangedEventBase<bool>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupMutedAll;
}