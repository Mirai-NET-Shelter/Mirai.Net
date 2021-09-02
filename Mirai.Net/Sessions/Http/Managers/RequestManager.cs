using System.Threading.Tasks;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Internal;

namespace Mirai.Net.Sessions.Http.Managers
{
    public static class RequestManager
    {
        /// <summary>
        ///     处理好友申请
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewFriendRequestedAsync(NewFriendRequestedEvent requestedEvent,
            NewFriendRequestHandlers handler, string message = "")
        {
            var payload = new
            {
                eventId = requestedEvent.EventId,
                fromId = requestedEvent.FromId,
                groupId = requestedEvent.GroupId,
                operate = handler,
                message
            };

            _ = await HttpEndpoints.NewFriendRequested.PostJsonAsync(payload);
        }
        
        /// <summary>
        ///     处理新成员入群申请,需要管理员权限
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewMemberRequestedAsync(NewMemberRequestedEvent requestedEvent,
            NewMemberRequestHandlers handler, string message = "")
        {
            var payload = new
            {
                eventId = requestedEvent.EventId,
                fromId = requestedEvent.FromId,
                groupId = requestedEvent.GroupId,
                operate = handler,
                message
            };

            _ = await HttpEndpoints.MemberJoinRequested.PostJsonAsync(payload);
        }

        /// <summary>
        ///     处理bot被邀请进群申请
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public static async Task HandleNewInvitationRequestedAsync(NewInvitationRequestedEvent requestedEvent,
            NewInvitationRequestHandlers handler, string message)
        {
            var payload = new
            {
                eventId = requestedEvent.EventId,
                fromId = requestedEvent.FromId,
                groupId = requestedEvent.GroupId,
                operate = handler,
                message
            };

            _ = await HttpEndpoints.BotInvited.PostJsonAsync(payload);
        }
    }
}