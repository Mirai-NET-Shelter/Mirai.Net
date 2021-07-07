using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Message;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Managers
{
    public class MessageManager
    {
        private readonly MiraiBot _bot;

        public MessageManager(MiraiBot bot)
        {
            _bot = bot;
        }

        /// <summary>
        /// 发送一条好友消息，并返回消息id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendFriendMessage(string id, params MessageBase[] chain)
        {
            var payload = new
            {
                target = id,
                messageChain = chain
            }.ToJsonString();
            var response = await _bot.PostJson("sendFriendMessage", payload);

            return response.ToJObject().Fetch("messageId");
        }
        
        /// <summary>
        /// 回复指定的消息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendFriendMessage(string id, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                target = id,
                messageChain = chain,
                quote = messageId
            }.ToJsonString();
            var response = await _bot.PostJson("sendFriendMessage", payload);

            return response.ToJObject().Fetch("messageId");
        }

        /// <summary>
        /// 发送一条群消息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendGroupMessage(string id, params MessageBase[] chain)
        {
            var payload = new
            {
                target = id,
                messageChain = chain
            }.ToJsonString();
            var response = await _bot.PostJson("sendGroupMessage", payload);

            return response.ToJObject().Fetch("messageId");
        }
        
        /// <summary>
        /// 回复一条群消息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public async Task<string> SendGroupMessage(string id, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                target = id,
                messageChain = chain,
                quote = messageId
            }.ToJsonString();
            var response = await _bot.PostJson("sendGroupMessage", payload);

            return response.ToJObject().Fetch("messageId");
        }
        
        /// <summary>
        /// 发送一条临时会话消息
        /// </summary>
        /// <param name="group"></param>
        /// <param name="chain"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public async Task<string> SendTempMessage(string qq, string group, params MessageBase[] chain)
        {
            var payload = new
            {
                qq,
                group,
                messageChain = chain,
            }.ToJsonString();
            var response = await _bot.PostJson("sendTempMessage", payload);

            return response.ToJObject().Fetch("messageId");
        }

        /// <summary>
        /// 回复一条临时会话消息
        /// </summary>
        /// <param name="group"></param>
        /// <param name="messageId"></param>
        /// <param name="chain"></param>
        /// <param name="qq"></param>
        /// <returns></returns>
        public async Task<string> SendTempMessage(string qq, string group, string messageId, params MessageBase[] chain)
        {
            var payload = new
            {
                qq,
                group,
                messageChain = chain,
                quote = messageId
            }.ToJsonString();
            var response = await _bot.PostJson("sendTempMessage", payload);

            return response.ToJObject().Fetch("messageId");
        }

        /// <summary>
        /// 戳一戳
        /// </summary>
        /// <param name="target">戳一戳的目标, QQ号, 可以为 bot QQ号</param>
        /// <param name="subject">戳一戳接受主体(上下文), 戳一戳信息会发送至该主体, 为群号/好友QQ号</param>
        /// <param name="kind">上下文类型, 可选值 Friend, Group, Stranger</param>
        public async Task SendNudge(string target, string subject, MessageReceiveType kind)
        {
            var payload = new
            {
                target,
                subject,
                kind
            }.ToJsonString();
            
            await _bot.PostJson("sendNudge", payload);
        }

        /// <summary>
        /// 撤回一条消息
        /// </summary>
        public async Task Recall(string id)
        {
            var payload = new
            {
                target = id
            }.ToJsonString();
            
            await _bot.PostJson("recall", payload);
        }
    }
}