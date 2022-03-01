using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.OtherClient;

/// <summary>
/// 其它客户端上线
/// </summary>
public class OtherClientOnlineEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.OtherClientOnline;

    /// <summary>
    /// 啥客户端
    /// </summary>
    [JsonProperty("client")]
    public Shared.OtherClient Client { get; set; }
    
    /// <summary>
    /// 详细设备类型
    /// </summary>
    [JsonProperty("kind")]
    public long Kind {get; set;}
}