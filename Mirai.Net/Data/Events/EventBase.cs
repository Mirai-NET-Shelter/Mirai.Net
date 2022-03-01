using Manganese.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events;

/// <summary>
/// 事件基类
/// </summary>
public class EventBase
{
    /// <summary>
    /// 你又看不到这个
    /// </summary>
    protected EventBase()
    {
    }

    /// <summary>
    /// 事件类型
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual Events Type { get; set; }

    /// <summary>
    /// ToString实际上是ToJsonString也就是说会被序列化成JSON文本
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this.ToJsonString();
    }
}