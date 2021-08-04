using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions.Managers;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class MessageManager
    {
        public readonly MiraiBot Bot = MiraiBotFactory.Bot;

        /// <summary>
        ///     发送好友消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendFriendMessage(string target, params MessageBase[] chain)
        {
            var payload = new
            {
                target,
                messageChain = chain
            };

            return await this.SendMessage(HttpEndpoints.SendFriendMessage, payload);
        }

        /// <summary>
        ///     发送群消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendGroupMessage(string target, params MessageBase[] chain)
        {
            var payload = new
            {
                target,
                messageChain = chain
            };

            return await this.SendMessage(HttpEndpoints.SendGroupMessage, payload);
        }

        /// <summary>
        ///     发送群临时消息
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="group"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendTempMessage(string qq, string group, params MessageBase[] chain)
        {
            var payload = new
            {
                qq,
                group,
                messageChain = chain
            };

            return await this.SendMessage(HttpEndpoints.SendTempMessage, payload);
        }

        /// <summary>
        ///     发送头像戳一戳
        /// </summary>
        /// <param name="target">戳一戳的目标</param>
        /// <param name="subject">在什么地方戳</param>
        /// <param name="kind">只可以选Friend, Strange和Group</param>
        public async Task SendNudge(string target, string subject, MessageReceivers kind)
        {
            var payload = new
            {
                target,
                subject,
                kind = kind.ToString()
            };

            await this.SendOperate(HttpEndpoints.SendNudge, payload);
        }

        /// <summary>
        ///     撤回消息
        /// </summary>
        /// <param name="messageId">消息id</param>
        public async Task Recall(string messageId)
        {
            var payload = new
            {
                target = messageId
            };

            await this.SendOperate(HttpEndpoints.Recall, payload);
        }

        /// <summary>
        ///     回复好友消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> QuoteFriendMessage(string target, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                target,
                quote = messageId,
                messageChain = chain
            };

            return await this.SendMessage(HttpEndpoints.SendFriendMessage, payload);
        }

        /// <summary>
        ///     回复群消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> QuoteGroupMessage(string target, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                target,
                quote = messageId,
                messageChain = chain
            };

            return await this.SendMessage(HttpEndpoints.SendGroupMessage, payload);
        }

        /// <summary>
        ///     回复临时消息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> QuoteTempMessage(string target, string group, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                qq = target,
                group,
                quote = messageId,
                messageChain = chain
            };

            return await this.SendMessage(HttpEndpoints.SendTempMessage, payload);
        }

        #region Overloads

        /// <see cref="QuoteFriendMessage(string,string,Mirai.Net.Data.Messages.MessageBase[])" />
        public async Task<string> QuoteFriendMessage(long target, string messageId, params MessageBase[] chain)
        {
            return await QuoteFriendMessage(target.ToString(), messageId, chain);
        }

        /// <see cref="QuoteGroupMessage(string,string,Mirai.Net.Data.Messages.MessageBase[])" />
        public async Task<string> QuoteGroupMessage(long target, string messageId, params MessageBase[] chain)
        {
            return await QuoteGroupMessage(target.ToString(), messageId, chain);
        }

        /// <see cref="QuoteTempMessage(string,string,Mirai.Net.Data.Messages.MessageBase[])" />
        public async Task<string> QuoteTempMessage(long target, long group, string messageId, params MessageBase[] chain)
        {
            return await QuoteTempMessage(target.ToString(), group.ToString(), messageId, chain);
        }

        /// <see cref="SendNudge(string,string,Mirai.Net.Data.Messages.MessageReceivers)" />
        public async Task SendNudge(long target, long subject, MessageReceivers kind)
        {
            await SendNudge(target.ToString(), subject.ToString(), kind);
        }


        /// <see cref="SendFriendMessage(string,Mirai.Net.Data.Messages.MessageBase[])" />
        public async Task<string> SendFriendMessage(long target, params MessageBase[] chain)
        {
            return await SendFriendMessage(target.ToString(), chain);
        }


        /// <see cref="SendGroupMessage(string,Mirai.Net.Data.Messages.MessageBase[])" />
        public async Task<string> SendGroupMessage(long target, params MessageBase[] chain)
        {
            return await SendGroupMessage(target.ToString(), chain);
        }


        /// <see cref="SendTempMessage(string,string,Mirai.Net.Data.Messages.MessageBase[])" />
        public async Task<string> SendTempMessage(long qq, long group, params MessageBase[] chain)
        {
            return await SendTempMessage(qq.ToString(), group.ToString(), chain);
        }

        #endregion
    }
}