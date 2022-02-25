using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 商城表情
/// <remarks>目前商城表情仅支持接收和转发，不支持构造发送</remarks>
/// </summary>
public class MarketFaceMessage : MessageBase
{
    public override Messages Type { get; set; } = Messages.MarketFace;
    
    [JsonProperty("id")]
    public string Id {get; set;}
    
    [JsonProperty("name")]
    public string Name {get; set;}
}