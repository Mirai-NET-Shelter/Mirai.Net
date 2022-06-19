namespace Mirai.Net.Data.Messages;

/// <summary>
/// 消息类型
/// </summary>
public enum Messages
{
    /// <summary>
    /// 源消息
    /// </summary>
    Source,
    /// <summary>
    /// 引用消息
    /// </summary>
    Quote,
    /// <summary>
    /// @消息
    /// </summary>
    At,
    /// <summary>
    /// @全体成员消息
    /// </summary>
    AtAll,
    /// <summary>
    /// qq表情消息
    /// </summary>
    Face,
    /// <summary>
    /// 纯文本消息
    /// </summary>
    Plain,
    /// <summary>
    /// 图片消息
    /// </summary>
    Image,
    /// <summary>
    /// 闪照消息
    /// </summary>
    FlashImage,
    /// <summary>
    /// 语音消息
    /// </summary>
    Voice,
    /// <summary>
    /// xml消息
    /// </summary>
    Xml,
    /// <summary>
    /// json消息
    /// </summary>
    Json,
    /// <summary>
    /// app消息
    /// </summary>
    App,
    /// <summary>
    /// 不知道是啥玩意消息
    /// </summary>
    Poke,
    /// <summary>
    /// 骰子消息
    /// </summary>
    Dice,
    /// <summary>
    /// 音乐分享消息
    /// </summary>
    MusicShare,
    /// <summary>
    /// 转发消息
    /// </summary>
    Forward,
    /// <summary>
    /// 文件消息
    /// </summary>
    File,
    /// <summary>
    /// 商城表情消息
    /// </summary>
    MarketFace,
    /// <summary>
    /// mirai码消息
    /// </summary>
    MiraiCode,
    /// <summary>
    /// 未知类型的消息
    /// </summary>
    Unknown
}