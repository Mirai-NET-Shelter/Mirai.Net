using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// @某人
/// </summary>
public record AtMessage : MessageBase
{
    /// <summary>
    /// 带参数的构造器
    /// </summary>
    /// <param name="target">要@的人的qq</param>
    public AtMessage(string target)
    {
        Target = target;
    }

    /// <summary>
    /// 
    /// </summary>
    public AtMessage()
    {
    }

    /// <summary>
    ///     群员QQ号
    /// </summary>
    [JsonProperty("target")]
    public string Target { get; set; }

    /// <summary>
    ///     At时显示的文字，发送消息时无效，自动使用群名片，默认为空
    /// </summary>
    [JsonProperty("display")]
    internal string Display { get; set; } = "";

    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.At;
}