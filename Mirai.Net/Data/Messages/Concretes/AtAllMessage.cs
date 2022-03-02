namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// @全体成员
/// </summary>
public class AtAllMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.AtAll;
}