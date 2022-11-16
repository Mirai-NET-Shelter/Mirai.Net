using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    /// <param name="messageId">消息id</param>
    /// <param name="target">好友id或群id</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> GetMessageReceiverByIdAsync<T>(string messageId, string target) where T : MessageReceiverBase
    {
        var response = await HttpEndpoints.MessageFromId.GetAsync(new
        {
            messageId,
            target
        });

        var data = response.Fetch("data")!;
        var receiver = JsonConvert.DeserializeObject<T>(data)!;
        receiver.MessageChain = data.Fetch("messageChain").DeserializeMessageChain();

        return receiver;
    }

    /// <summary>
    /// 获取漫游消息（目前仅支持好友）
    /// </summary>
    /// <param name="target">好友id或群id</param>
    /// <param name="timeStart">起始时间, UTC+8 时间戳, 单位为秒. 可以为 0, 即表示从可以获取的最早的消息起. 负数将会被看是 0.</param>
    /// <param name="timeEnd">结束时间, UTC+8 时间戳, 单位为秒. 可以为 <c>long.MaxValue</c>, 即表示到可以获取的最晚的消息为止. 低于 timeStart 的值将会被看作是 timeStart 的值.</param>
    /// <returns></returns>
    public static async Task<IEnumerable<MessageReceiverBase>> GetRoamingMessagesAsync(string target, long timeStart = 0, long timeEnd = 0)
    {
        var response = await HttpEndpoints.RoamingMessages.PostJsonAsync(new
        {
            timeStart,
            timeEnd,
            target = target.ToInt64(),
        });
        return JsonConvert.DeserializeObject<IEnumerable<MessageReceiverBase>>(response.Fetch("data"));
    }

    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(string friendId, MessageChain chain)
    {
        var payload = new
        {
            target = friendId,
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
    public static async Task<string> SendGroupMessageAsync(string groupId, MessageChain chain)
    {
        var payload = new
        {
            target = groupId,
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
    ///     回复消息
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
}
