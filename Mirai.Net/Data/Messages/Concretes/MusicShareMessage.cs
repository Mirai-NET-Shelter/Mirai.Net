using Newtonsoft.Json;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 音乐分享
/// </summary>
public class MusicShareMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.MusicShare;

    /// <summary>
    /// 类型
    /// </summary>
    [JsonProperty("kind")] public string Kind { get; set; }

    /// <summary>
    /// 标题
    /// </summary>
    [JsonProperty("title")] public string Title { get; set; }

    /// <summary>
    /// 概述
    /// </summary>
    [JsonProperty("summary")] public string Summary { get; set; }

    /// <summary>
    /// 跳转链接
    /// </summary>
    [JsonProperty("jumpUrl")] public string JumpUrl { get; set; }

    /// <summary>
    /// 封面链接
    /// </summary>
    [JsonProperty("pictureUrl")] public string PictureUrl { get; set; }

    /// <summary>
    /// 音乐链接
    /// </summary>
    [JsonProperty("musicUrl")] public string MusicUrl { get; set; }

    /// <summary>
    /// 简介
    /// </summary>
    [JsonProperty("brief")] public string Brief { get; set; }
}