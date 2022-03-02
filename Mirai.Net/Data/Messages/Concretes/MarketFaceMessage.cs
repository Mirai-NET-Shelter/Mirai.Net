using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 商城表情
/// <remarks>目前商城表情仅支持接收和转发，不支持构造发送</remarks>
/// </summary>
public class MarketFaceMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.MarketFace;
    
    /// <summary>
    /// 表情id
    /// </summary>
    [JsonProperty("id")]
    public string Id {get; set;}
    
    /// <summary>
    /// 表情名称
    /// </summary>
    [JsonProperty("name")]
    public string Name {get; set;}
}