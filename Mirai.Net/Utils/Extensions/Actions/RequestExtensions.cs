using System.Threading.Tasks;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions.Actions
{
    public static class RequestExtensions
    {
        /// <summary>
        /// 处理好友请求
        /// </summary>
        /// <param name="event"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewFriendRequested(this NewFriendRequestedEvent @event, NewFriendRequestHandlers handler, string message = "")
        {
            await MiraiBotFactory.Bot.GetManager<RequestManager>().HandleNewFriendRequested(@event, handler, message);
        }

        /// <summary>
        /// 处理新成员加群请求
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewMemberRequested(this NewMemberRequestedEvent requestedEvent,
            NewMemberRequestHandlers handler, string message = "")
        {
            await MiraiBotFactory.Bot.GetManager<RequestManager>()
                .HandleNewMemberRequested(@requestedEvent, handler, message);
        }

        /// <summary>
        /// 处理bot被邀请进群请求
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewInvitationRequested(NewInvitationRequestedEvent requestedEvent,
            NewInvitationRequestHandlers handler, string message)
        {
            await MiraiBotFactory.Bot.GetManager<RequestManager>()
                .HandleNewInvitationRequested(requestedEvent, handler, message);
        }
    }
}