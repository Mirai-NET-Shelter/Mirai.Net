using Mirai.Net.Data.Shared;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mirai.Net.Data.Events.Concretes.Group;

/// <summary>
/// Bot在群内的权限改变，操作者一定是群主
/// </summary>
public record PermissionChangedEvent : EventBase
{
    /// <summary>
    /// 事件类型
    /// </summary>
    public override Events Type { get; set; } = Events.PermissionChanged;

    /// <summary>
    /// 原来的权限
    /// </summary>
    [JsonProperty("origin")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Permissions Origin { get; set; }

    /// <summary>
    /// 目前的权限
    /// </summary>
    [JsonProperty("current")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Permissions Current { get; set; }

    /// <summary>
    /// 事发群
    /// </summary>
    [JsonProperty("group")] public Shared.Group Group { get; set; }
}