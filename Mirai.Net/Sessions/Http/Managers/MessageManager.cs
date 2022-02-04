using System.Threading.Tasks;
using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json;

namespace Mirai.Net.Sessions.Http.Managers;

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
    public static async Task<T> GetMessageReceiverByIdAsync<T>(string messageId) where T : MessageReceiverBase
    {
        var response = await HttpEndpoints.MessageFromId.GetAsync(new
        {
            id = messageId
        });

        return JsonConvert.DeserializeObject<T>(response);
    }
    
    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(string target, params MessageBase[] chain)
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
    public static async Task<string> SendFriendMessageAsync(this Friend friend, params MessageBase[] chain)
    {
        return await SendFriendMessageAsync(friend.Id, chain);
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="chain"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(string target, params MessageBase[] chain)
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
    public static async Task<string> SendGroupMessageAsync(this Group group, params MessageBase[] chain)
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
    public static async Task<string> SendTempMessageAsync(string qq, string group, params MessageBase[] chain)
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
    public static async Task<string> SendTempMessageAsync(this Member member, params MessageBase[] chain)
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
    public static async Task RecallAsync(string messageId)
    {
        var payload = new
        {
            target = messageId
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
        params MessageBase[] chain)
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
        params MessageBase[] chain)
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
    public static async Task<string> QuoteGroupMessageAsync(string target, string messageId, params MessageBase[] chain)
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
        params MessageBase[] chain)
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
        params MessageBase[] chain)
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
        params MessageBase[] chain)
    {
        return await QuoteTempMessageAsync(member.Group.Id, member.Group.Id, messageId);
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
        return await SendFriendMessageAsync(target, message.Append());
    }

    /// <summary>
    ///     发送好友消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendFriendMessageAsync(this Friend target, string message)
    {
        return await SendFriendMessageAsync(target, message.Append());
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
        return await SendTempMessageAsync(target, group, message.Append());
    }

    /// <summary>
    ///     发送临时消息
    /// </summary>
    /// <param name="member"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendTempMessageAsync(this Member member, string message)
    {
        return await SendTempMessageAsync(member, message.Append());
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="target"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(string target, string message)
    {
        return await SendGroupMessageAsync(target, message.Append());
    }

    /// <summary>
    ///     发送群消息
    /// </summary>
    /// <param name="group"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static async Task<string> SendGroupMessageAsync(this Group group, string message)
    {
        return await SendGroupMessageAsync(group, message.Append());
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
        return await QuoteFriendMessageAsync(target, messageId, message.Append());
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
        return await QuoteFriendMessageAsync(target, messageId, message.Append());
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
        return await QuoteGroupMessageAsync(target, messageId, message.Append());
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
        return await QuoteGroupMessageAsync(target, messageId, message.Append());
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
        return await QuoteTempMessageAsync(memberId, group, messageId, message.Append());
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
        return await QuoteTempMessageAsync(member, messageId, message.Append());
    }

    #endregion
}