using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Concretes.OtherClient;

public class OtherClientOnlineEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.OtherClientOnline;

    [JsonProperty("client")]
    public Shared.OtherClient Client { get; set; }
    
    [JsonProperty("kind")]
    public string Kind {get; set;}
}