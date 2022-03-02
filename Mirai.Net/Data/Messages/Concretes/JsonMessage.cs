using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// json消息
/// </summary>
public class JsonMessage : MessageBase
{
    ///json文本   
    [JsonProperty("json")] public string Json { get; set; }

    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Json;
}