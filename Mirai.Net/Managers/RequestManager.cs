using System.Threading.Tasks;
using Mirai.Net.Data.Contact;
using Mirai.Net.Data.Events.Apply;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Managers
{
    /// <summary>
    /// 此类用来处理各种请求事件
    /// </summary>
    public class RequestManager
    {
        private readonly MiraiBot _bot;

        public RequestManager(MiraiBot bot)
        {
            _bot = bot;
        }
        
        /// <summary>
        /// 处理添加好友请求
        /// </summary>
        /// <param name="args"></param>
        /// <param name="operate"></param>
        /// <param name="replyMessage"></param>
        public async Task HandleFriendRequest(NewFriendRequestEventArgs args, NewFriendRequestOperate operate, string replyMessage = "")
        {
            var payload = new
            {
                eventId = args.EventId,
                fromId = args.FromId,
                groupId = args.GroupId,
                operate,
                message = replyMessage
            }.ToJsonString();

            await _bot.PostJson("resp/newFriendRequestEvent", payload);
        }
        
        /// <summary>
        /// 处理用户加群事件
        /// </summary>
        /// <param name="args"></param>
        /// <param name="operate"></param>
        /// <param name="replyMessage"></param>
        public async Task HandleGroupNewMemberRequest(MemberJoinRequestEventArgs args, NewGroupMemberRequest operate, string replyMessage = "")
        {
            var payload = new
            {
                eventId = args.EventId,
                fromId = args.FromId,
                groupId = args.GroupId,
                operate,
                message = replyMessage
            }.ToJsonString();

            await _bot.PostJson("resp/memberJoinRequestEvent", payload);
        }

        /// <summary>
        /// 处理Bot被邀请入群申请
        /// </summary>
        /// <param name="args"></param>
        /// <param name="operate">是否同意</param>
        public async Task HandleBotInvitedToGroup(BotInvitedJoinGroupRequestEvent args, bool operate)
        {
            var payload = new
            {
                eventId = args.EventId,
                fromId = args.FromId,
                groupId = args.GroupId,
                operate = (operate ? 0 : 1)
            }.ToJsonString();

            await _bot.PostJson("resp/memberJoinRequestEvent", payload);
        }
    }
}