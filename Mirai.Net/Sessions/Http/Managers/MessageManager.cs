using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Internal;
using Mirai.Net.Utils.Scaffolds;

namespace Mirai.Net.Sessions.Http.Managers
{
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
        public static async Task<string> QuoteFriendMessageAsync(string target, string messageId, params MessageBase[] chain)
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
        ///     回复临时消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> QuoteTempMessageAsync(string target, string group, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                qq = target,
                group,
                quote = messageId,
                messageChain = chain
            };

            return await SendMessageAsync(HttpEndpoints.SendTempMessage, payload);
        }
        
        #endregion

        #region Exposed overloads

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendFriendMessageAsync(string target, string message)
        {
            return await SendFriendMessageAsync(target, message.Append());
        }

        /// <summary>
        /// 发送临时消息
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
        /// 引用好友消息
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
        /// 引用群消息
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
        /// 引用临时消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="messageId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> QuoteTempMessageAsync(string target, string group, string messageId, string message)
        {
            return await QuoteTempMessageAsync(target, group, messageId, message.Append());
        }

        #endregion
    }
}