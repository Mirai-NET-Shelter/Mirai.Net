namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// 群内是否允许匿名聊天的状态改变
/// </summary>
public class GroupAllowedAnonymousChatEvent : GroupSettingChangedEventBase<bool>
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.GroupAllowedAnonymousChat;
}