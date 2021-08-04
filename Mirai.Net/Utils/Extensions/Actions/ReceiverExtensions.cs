using System.Linq;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions.Actions
{
    public static class ReceiverExtensions
    {
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMessage(this GroupMessageReceiver receiver, params MessageBase[] chain)
        {
            return await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .SendGroupMessage(receiver.Sender.Group.Id, chain);
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> SendFriendMessage(this FriendMessageReceiver receiver, params MessageBase[] chain)
        {
            return await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .SendFriendMessage(receiver.Sender.Id, chain);
        }

        /// <summary>
        /// 发送临时消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> SendTempMessage(this TempMessageReceiver receiver, params MessageBase[] chain)
        {
            return await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .SendTempMessage(receiver.Sender.Id, receiver.Sender.Group.Id, chain);
        }

        /// <summary>
        /// 撤回收到的消息
        /// </summary>
        /// <param name="receiver"></param>
        public static async Task Recall(this MessageReceiverBase receiver)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;
            await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .Recall(id);
        }

        public static async Task<string> QuoteFriendMessage(this FriendMessageReceiver receiver, params MessageBase[] chain)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .QuoteFriendMessage(receiver.Sender.Id, id, chain);
        }
        
        public static async Task<string> QuoteGroupMessage(this GroupMessageReceiver receiver, params MessageBase[] chain)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .QuoteGroupMessage(receiver.Sender.Id, id, chain);
        }
        
        public static async Task<string> QuoteTempMessage(this TempMessageReceiver receiver, params MessageBase[] chain)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MiraiBotFactory.Bot
                .GetManager<MessageManager>()
                .QuoteTempMessage(receiver.Sender.Id, receiver.Sender.Group.Id, id, chain);
        }
    }
}