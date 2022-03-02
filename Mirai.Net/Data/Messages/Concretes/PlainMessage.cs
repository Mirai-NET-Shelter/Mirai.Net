using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 纯文本消息
/// </summary>
public class PlainMessage : MessageBase
{
    /// <summary>
    /// 带参数的构造器
    /// </summary>
    /// <param name="text"></param>
    public PlainMessage(string text)
    {
        Text = text;
    }

    /// <summary>
    /// 
    /// </summary>
    public PlainMessage()
    {
    }

    /// <summary>
    /// 文本
    /// </summary>
    [JsonProperty("text")] public string Text { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Plain;

    /// <summary>
    /// 可以和string相互转换
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static implicit operator PlainMessage(string s)
    {
        return new PlainMessage(s);
    }

    /// <summary>
    /// 可以和string相互转换
    /// </summary>
    /// <param name="plainMessage"></param>
    /// <returns></returns>
    public static implicit operator string(PlainMessage plainMessage)
    {
        return plainMessage.Text;
    }
}