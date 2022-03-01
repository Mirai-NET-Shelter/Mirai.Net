using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.OtherClient;

public class OtherClientOfflineEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.OtherClientOffline;
    
    [JsonProperty("client")]
    public Shared.OtherClient Client {get; set;}
}