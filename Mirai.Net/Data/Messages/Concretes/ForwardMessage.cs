using System;
using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Sessions;
using Newtonsoft.Json;

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
    ///     消息节点
    /// </summary>
    [JsonProperty("nodeList")]
    public IEnumerable<ForwardNode> NodeList { get; set; }

    /// <summary>
    /// 从单个人的消息中构建转发消息
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="chains"></param>
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
}