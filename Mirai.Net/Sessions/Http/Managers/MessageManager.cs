using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Sessions.Http.Managers;

/// <summary>
/// 消息管理器
/// </summary>
public static class MessageManager
{
    #region Private helpers

    private static async Task<string> SendMessageAsync(HttpEndpoints endpoints, object payload)
    {
        var response = await endpoints.PostJsonAsync(payload);

        return response.Fetch("messageId");
    }

    #endregion

    #region Exposed

    /// <summary>
    /// 由消息id获取一条消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [Obsolete("此方法在mirai-api-http 2.6.0及以上版本会导致异常")]
    public static async Task<T> GetMessageReceiverByIdAsync<T>(string messageId) where T : MessageReceiverBase
    {
        var response = await HttpEndpoints.MessageFromId.GetAsync(new
        {
            id = messageId
        });

        return JsonConvert.DeserializeObject<T>(response);
    }

    /// <summary>
    /// 获取一条消息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="messageId">消息id</param>
    /// <param name="target">好友id或群id</param>
    /// <returns></returns>
    public static async Task<T> GetMessageReceiverAsync<T>(string messageId, string target) where T : MessageReceiverBase
    {
        var response = await HttpEndpoints.MessageFromId.GetAsync(new
        {
            id = messageId,
            target
        });

        return JsonConvert.DeserializeObject<T>(response);
    }

    /// <summary>
    /// 获取漫游消息（目前仅支持好友）
    /// </summary>
    /// <param name="target">好友id或群id</param>
    /// <param name="timeStart">起始时间, UTC+8 时间戳, 单位为秒. 可以为 0, 即表示从可以获取的最早的消息起. 负数将会被看是 0.</param>
    /// <param name="timeEnd">结束时间, UTC+8 时间戳, 单位为秒. 可以为 <c>long.MaxValue</c>, 即表示到可以获取的最晚的消息为止. 低于 timeStart 的值将会被看作是 timeStart 的值.</param>
    /// <returns></returns>
    public static async Task<IEnumerable<MessageChain>> GetRoamingMessagesAsync(string target, string timeStart, string timeEnd)
    {
        var response = await HttpEndpoints.RoamingMessages.GetAsync(new
        {
            timeStart,
            timeEnd,
            target
        });

        return ((JArray)response.ToJObject()["data"]).Values<MessageChain>();
    }

    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(string target, MessageChain chain)
    {
        var payload = new
        {
            target,
            messageChain = chain
        };

        return await SendMessageAsync(HttpEndpoints.SendFriendMessage, payload);
    }

    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="friend"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(this Friend friend, MessageChain chain)
    {
        return await SendFriendMessageAsync(friend.Id, chain);
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(string target, MessageChain chain)
    {
        var payload = new
        {
            target,
            messageChain = chain
        };

        return await SendMessageAsync(HttpEndpoints.SendGroupMessage, payload);
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="group"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(this Group group, MessageChain chain)
    {
        return await SendGroupMessageAsync(group.Id, chain);
    }

    /// <summary>
    ///     发送群临时消息
    /// </summary>
    /// <param name="qq"></param>
    /// <param name="group"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendTempMessageAsync(string qq, string group, MessageChain chain)
    {
        var payload = new
        {
            qq,
            group,
            messageChain = chain
        };

        return await SendMessageAsync(HttpEndpoints.SendTempMessage, payload);
    }

    /// <summary>
    ///     发送群临时消息
    /// </summary>
    /// <param name="member"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendTempMessageAsync(this Member member, MessageChain chain)
    {
        return await SendTempMessageAsync(member.Id, member.Group.Id, chain);
    }

    /// <summary>
    ///     发送头像戳一戳
    /// </summary>
    /// <param name="target">戳一戳的目标</param>
    /// <param name="subject">在什么地方戳</param>
    /// <param name="kind">只可以选Friend, Strange和Group</param>
    public static async Task SendNudgeAsync(string target, string subject, MessageReceivers kind)
    {
        var payload = new
        {
            target,
            subject,
            kind = kind.ToString()
        };

        await HttpEndpoints.SendNudge.PostJsonAsync(payload);
    }

    /// <summary>
    ///     撤回消息
    /// </summary>
    /// <param name="messageId">消息id</param>
    [Obsolete("此方法在mirai-api-http 2.6.0及以上版本会导致异常")]
    public static async Task RecallAsync(string messageId)
    {
        var payload = new
        {
            target = messageId
        };

        await HttpEndpoints.Recall.PostJsonAsync(payload);
    }

    /// <summary>
    ///     撤回消息
    /// </summary>
    /// <param name="messageId">消息id</param>
    /// <param name="target">好友id或群id</param>
    public static async Task RecallAsync(string messageId, string target)
    {
        var payload = new
        {
            target,
            messageId
        };

        await HttpEndpoints.Recall.PostJsonAsync(payload);
    }

    /// <summary>
    ///     回复好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="messageId"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> QuoteFriendMessageAsync(string target, string messageId,
        MessageChain chain)
    {
        var payload = new
        {
            target,
            quote = messageId,
            messageChain = chain
        };

        return await SendMessageAsync(HttpEndpoints.SendFriendMessage, payload);
    }

    /// <summary>
    ///     回复好友消息
    /// </summary>
    /// <param name="friend"></param>
    /// <param name="messageId"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> QuoteFriendMessageAsync(this Friend friend, string messageId,
        MessageChain chain)
    {
        return await QuoteFriendMessageAsync(friend.Id, messageId, chain);
    }

    /// <summary>
    ///     回复群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="messageId"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> QuoteGroupMessageAsync(string target, string messageId, MessageChain chain)
    {
        var payload = new
        {
            target,
            quote = messageId,
            messageChain = chain
        };

        return await SendMessageAsync(HttpEndpoints.SendGroupMessage, payload);
    }

    /// <summary>
    ///     回复群消息
    /// </summary>
    /// <param name="group"></param>
    /// <param name="messageId"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> QuoteGroupMessageAsync(this Group group, string messageId,
        MessageChain chain)
    {
        return await QuoteGroupMessageAsync(group.Id, messageId, chain);
    }

    /// <summary>
    ///     回复临时消息
    /// </summary>
    /// <param name="memberId"></param>
    /// <param name="group"></param>
    /// <param name="messageId"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> QuoteTempMessageAsync(string memberId, string group, string messageId,
        MessageChain chain)
    {
        var payload = new
        {
            qq = memberId,
            group,
            quote = messageId,
            messageChain = chain
        };

        return await SendMessageAsync(HttpEndpoints.SendTempMessage, payload);
    }

    /// <summary>
    ///     回复临时消息
    /// </summary>
    /// <param name="member"></param>
    /// <param name="messageId"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> QuoteTempMessageAsync(this Member member, string messageId,
        MessageChain chain)
    {
        return await QuoteTempMessageAsync(member.Id, member.Group.Id, messageId, chain);
    }

    #endregion

    #region Exposed overloads

    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(string target, string message)
    {
        return await SendFriendMessageAsync(target, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(this Friend target, string message)
    {
        return await SendFriendMessageAsync(target, new MessageChainBuilder().Plain(message).Build());
    }


    /// <summary>
    ///     发送临时消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="group"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendTempMessageAsync(string target, string group, string message)
    {
        return await SendTempMessageAsync(target, group, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     发送临时消息
    /// </summary>
    /// <param name="member"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendTempMessageAsync(this Member member, string message)
    {
        return await SendTempMessageAsync(member, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(string target, string message)
    {
        return await SendGroupMessageAsync(target, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="group"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(this Group group, string message)
    {
        return await SendGroupMessageAsync(group, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     引用好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="messageId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> QuoteFriendMessageAsync(string target, string messageId, string message)
    {
        return await QuoteFriendMessageAsync(target, messageId, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     引用好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="messageId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> QuoteFriendMessageAsync(this Friend target, string messageId, string message)
    {
        return await QuoteFriendMessageAsync(target, messageId, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     引用群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="messageId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> QuoteGroupMessageAsync(string target, string messageId, string message)
    {
        return await QuoteGroupMessageAsync(target, messageId, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     引用群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="messageId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> QuoteGroupMessageAsync(this Group target, string messageId, string message)
    {
        return await QuoteGroupMessageAsync(target, messageId, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     引用临时消息
    /// </summary>
    /// <param name="memberId"></param>
    /// <param name="group"></param>
    /// <param name="messageId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> QuoteTempMessageAsync(string memberId, string group, string messageId,
        string message)
    {
        return await QuoteTempMessageAsync(memberId, group, messageId, new MessageChainBuilder().Plain(message).Build());
    }

    /// <summary>
    ///     引用临时消息
    /// </summary>
    /// <param name="member"></param>
    /// <param name="messageId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> QuoteTempMessageAsync(this Member member, string messageId, string message)
    {
        return await QuoteTempMessageAsync(member, messageId, new MessageChainBuilder().Plain(message).Build());
    }

    #endregion
}
