using System;
using System.Linq;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Managers;
using Mirai.Net.Utils.Internal;

namespace Mirai.Net.Utils.Scaffolds
{
    public static class MiraiScaffold
    {
        /// <summary>
        ///     拓展方法，获取mirai-api-http插件的版本，此方法不需要经过任何认证
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetPluginVersionAsync(this MiraiBot bot)
        {
            try
            {
                var response = await HttpEndpoints.About.GetAsync();

                response.EnsureSuccess(response);
                
                return response.Fetch("data.version");
            }
            catch (Exception e)
            {
                throw new Exception($"获取失败: {e.Message}\n{bot}");
            }
        }
        
        /// <summary>
        /// 寻找指定类型，并且转换
        /// </summary>
        public static IObservable<TSource> WhereAndCast<TSource>(this IObservable<object> observable, Func<object, bool> predicate) where TSource : class
        {
            return observable.Where(x => predicate.Invoke(x as TSource)).Cast<TSource>();
        }
        
        /// <summary>
        /// 寻找指定类型，并且转换
        /// </summary>
        /// <param name="observable"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IObservable<TSource> WhereAndCast<TSource>(this IObservable<object> observable) where TSource : class
        {
            return observable.Where(x => x is TSource).Cast<TSource>();
        }
        
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMessageAsync(this GroupMessageReceiver receiver, params MessageBase[] chain)
        {
            return await MessageManager
                .SendGroupMessageAsync(receiver.Sender.Group.Id, chain);
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> SendFriendMessageAsync(this FriendMessageReceiver receiver, params MessageBase[] chain)
        {
            return await MessageManager
                .SendFriendMessageAsync(receiver.Sender.Id, chain);
        }

        /// <summary>
        /// 发送临时消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static async Task<string> SendTempMessageAsync(this TempMessageReceiver receiver, params MessageBase[] chain)
        {
            return await MessageManager
                .SendTempMessageAsync(receiver.Sender.Id, receiver.Sender.Group.Id, chain);
        }
        
        /// <summary>
        /// 发送群消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendGroupMessageAsync(this GroupMessageReceiver receiver, string message)
        {
            return await MessageManager
                .SendGroupMessageAsync(receiver.Sender.Group.Id, message);
        }

        /// <summary>
        /// 发送好友消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendFriendMessageAsync(this FriendMessageReceiver receiver, string message)
        {
            return await MessageManager
                .SendFriendMessageAsync(receiver.Sender.Id, message);
        }

        /// <summary>
        /// 发送临时消息
        /// </summary>
        /// <param name="receiver"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task<string> SendTempMessageAsync(this TempMessageReceiver receiver, string message)
        {
            return await MessageManager
                .SendTempMessageAsync(receiver.Sender.Id, receiver.Sender.Group.Id, message);
        }

        /// <summary>
        /// 撤回收到的消息
        /// </summary>
        /// <param name="receiver"></param>
        public static async Task RecallAsync(this MessageReceiverBase receiver)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;
            await MessageManager
                .RecallAsync(id);
        }

        public static async Task<string> QuoteFriendMessageAsync(this FriendMessageReceiver receiver, params MessageBase[] chain)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MessageManager
                .QuoteFriendMessageAsync(receiver.Sender.Id, id, chain);
        }
        
        public static async Task<string> QuoteGroupMessageAsync(this GroupMessageReceiver receiver, params MessageBase[] chain)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MessageManager
                .QuoteGroupMessageAsync(receiver.Sender.Id, id, chain);
        }
        
        public static async Task<string> QuoteTempMessageAsync(this TempMessageReceiver receiver, params MessageBase[] chain)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MessageManager
                .QuoteTempMessageAsync(receiver.Sender.Id, receiver.Sender.Group.Id, id, chain);
        }
        
        public static async Task<string> QuoteFriendMessageAsync(this FriendMessageReceiver receiver, string message)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MessageManager
                .QuoteFriendMessageAsync(receiver.Sender.Id, id, message);
        }
        
        public static async Task<string> QuoteGroupMessageAsync(this GroupMessageReceiver receiver, string message)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MessageManager
                .QuoteGroupMessageAsync(receiver.Sender.Id, id, message);
        }
        
        public static async Task<string> QuoteTempMessageAsync(this TempMessageReceiver receiver, string message)
        {
            var id = receiver.MessageChain.WhereAndCast<SourceMessage>().First().MessageId;

            return await MessageManager
                .QuoteTempMessageAsync(receiver.Sender.Id, receiver.Sender.Group.Id, id, message);
        }
        
        /// <summary>
        /// 处理好友请求
        /// </summary>
        /// <param name="event"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewFriendRequestedAsync(this NewFriendRequestedEvent @event, NewFriendRequestHandlers handler, string message = "")
        {
            await RequestManager.HandleNewFriendRequestedAsync(@event, handler, message);
        }

        /// <summary>
        /// 处理新成员加群请求
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewMemberRequestedAsync(this NewMemberRequestedEvent requestedEvent,
            NewMemberRequestHandlers handler, string message = "")
        {
            await RequestManager
                .HandleNewMemberRequestedAsync(@requestedEvent, handler, message);
        }

        /// <summary>
        /// 处理bot被邀请进群请求
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewInvitationRequestedAsync(NewInvitationRequestedEvent requestedEvent,
            NewInvitationRequestHandlers handler, string message)
        {
            await RequestManager
                .HandleNewInvitationRequestedAsync(requestedEvent, handler, message);
        }
    }
}