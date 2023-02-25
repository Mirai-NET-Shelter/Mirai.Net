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
    ///     预览卡片
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
        var chainsList= chains.ToList();
        var re = new ForwardMessage
        {
            Display = new ForwardDisplay
            {
                Title = "群聊的聊天记录",
                Brief = "[聊天记录]",
                Source = "聊天记录",
                Preview = chainsList.Select(c =>
                {
                    var plainText = c.GetPlainMessage();
                    return $"{name}:{ (string.IsNullOrEmpty(plainText) ? "图片或其他消息" : plainText)}";
                }).ToList(),
                Summary = $"查看{chainsList.Count}条转发消息"
            },
            NodeList = chainsList.Select(c => new ForwardNode
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
    /// 卡片预览
    /// </summary>
    public record ForwardDisplay
    {
        /// <summary>
        ///     标题(群聊的聊天记录)
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }
        /// <summary>
        ///     概要([聊天记录])
        /// </summary>
        [JsonProperty("brief")]
        public string Brief { get; set; }
        /// <summary>
        ///     来源 (聊天记录)
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
        /// <summary>
        ///     信息预览(["msg1", "msg2", "msg3", "msg4"])
        /// </summary>
        [JsonProperty("preview")]
        public List<string> Preview { get; set; }
        /// <summary>
        ///     总结(查看x条转发消息)
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}