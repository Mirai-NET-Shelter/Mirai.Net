using System.Threading.Tasks;
using Mirai.Net.Data.Events.Concretes.Request;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions.Managers;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class RequestManager
    {
        public readonly MiraiBot Bot = MiraiBotFactory.Bot;

        /// <summary>
        ///     处理好友申请
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public async Task HandleNewFriendRequested(NewFriendRequestedEvent requestedEvent,
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

            await this.SendOperate(HttpEndpoints.NewFriendRequested, payload);
        }

        /// <summary>
        ///     处理新成员入群申请,需要管理员权限
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public async Task HandleNewMemberRequested(NewMemberRequestedEvent requestedEvent,
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

            await this.SendOperate(HttpEndpoints.MemberJoinRequested, payload);
        }

        /// <summary>
        ///     处理bot被邀请进群申请
        /// </summary>
        /// <param name="requestedEvent"></param>
        /// <param name="handler"></param>
        /// <param name="message"></param>
        public async Task HandleNewInvitationRequested(NewInvitationRequestedEvent requestedEvent,
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

            await this.SendOperate(HttpEndpoints.BotInvited, payload);
        }
    }
}