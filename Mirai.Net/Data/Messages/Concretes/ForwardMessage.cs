using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mirai.Net.Data.Messages.Concretes;

/// <summary>
/// 转发的消息
/// </summary>
public record ForwardMessage : MessageBase
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public override Messages Type { get; set; } = Messages.Forward;

    /// <summary>
    /// 点进消息前的显示内容
    /// </summary>
    [JsonProperty("display")]
    public ForwardDisplay Display { get; set; }

    /// <summary>
    ///     消息节点
    /// </summary>
    [JsonProperty("nodeList")]
    public IEnumerable<ForwardNode> NodeList { get; set; }

    /// <summary>
    /// 从单个人的消息中构建转发消息
    /// </summary>
    /// <param name="id">某人的id</param>
    /// <param name="name">某人的昵称</param>
    /// <param name="chains">消息链的集合，每个消息链就是一条消息</param>
    /// <returns></returns>
    public static ForwardMessage FromChains(string id, string name, IEnumerable<MessageChain> chains)
    {
        var re = new ForwardMessage
        {
            NodeList = chains.Select(c => new ForwardNode
            {
                SenderId = id,
                SenderName = name,
                Time = DateTimeOffset.Now.ToUnixTimeSeconds().ToString(),
                MessageChain = c,
                SourceId = "114514"
            })
        };

        return re;
    }

    /// <summary>
    /// 转发的消息节点
    /// </summary>
    public record ForwardNode
    {
        /// <summary>
        ///     发送人QQ号
        /// </summary>
        [JsonProperty("senderId")]
        public string SenderId { get; set; }

        /// <summary>
        ///     发送时间
        /// </summary>
        [JsonProperty("time")]
        public string Time { get; set; }

        /// <summary>
        ///     显示名称
        /// </summary>
        [JsonProperty("senderName")]
        public string SenderName { get; set; }

        /// <summary>
        ///     消息数组
        /// </summary>
        [JsonProperty("messageChain")]
        public MessageChain MessageChain { get; set; }

        /// <summary>
        ///     可以只使用消息messageId，从缓存中读取一条消息作为节点
        /// </summary>
        [JsonProperty("sourceId")]
        public string SourceId { get; set; }
    }

    /// <summary>
    /// 未进入转发消息时的显示内容
    /// </summary>
    public record ForwardDisplay
    {
        /// <summary>
        ///     生成转发消息的外层显示
        /// </summary>
        /// <param name="title"></param>
        /// <param name="brief"></param>
        /// <param name="source"></param>
        /// <param name="preview"></param>
        /// <param name="summary"></param>
        public ForwardDisplay(string title = default, string brief = default, string source = default, IEnumerable<string> preview = default, string summary = default)
        {
            this.Title = title;

            this.Brief = brief;

            this.Source = source;

            this.Preview = preview;

            this.Summary = summary;
        }

        /// <summary>
        ///     标题
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     在未进入聊天页面时所产生的消息提示
        /// </summary>
        [JsonProperty("brief")]
        public string Brief { get; set; }

        /// <summary>
        ///     目前未发现在哪能显示，建议不填
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        ///     消息内容预览
        /// </summary>
        [JsonProperty("preview")]
        public IEnumerable<string> Preview { get; set; }

        /// <summary>
        ///     消息总结
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}