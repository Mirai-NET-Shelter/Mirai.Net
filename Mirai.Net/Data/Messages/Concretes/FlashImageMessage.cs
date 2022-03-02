namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 闪照，构造方式与<see cref="ImageMessage"/>相同
/// </summary>
public class FlashImageMessage : ImageMessage
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.FlashImage;
}