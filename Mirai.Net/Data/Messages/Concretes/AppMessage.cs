using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 小程序消息
/// </summary>
public class AppMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.App;

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("content")] public string Content { get; set; }
}