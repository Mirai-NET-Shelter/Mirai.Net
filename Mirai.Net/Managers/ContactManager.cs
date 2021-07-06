using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mirai.Net.Data.Contact;
using Mirai.Net.Data.Events.Apply;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Managers
{
    public class ContactManager
    {
        private readonly MiraiBot _bot;

        public ContactManager(MiraiBot bot)
        {
            _bot = bot;
        }

        /// <summary>
        /// 获取bot账号的好友列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Friend>> GetFriendList()
        {
            var response = await _bot.Get("friendList");
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<Friend>());
        }
        
        /// <summary>
        /// 获取bot账号的QQ群列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Group>> GetGroupList()
        {
            var response = await _bot.Get("groupList");
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<Group>());
        }
        
        /// <summary>
        /// 获取某个QQ群的成员列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GroupMember>> GetGroupMemberList(string id)
        {
            var response = await _bot.Get("memberList", new[]
            {
                ("target", id)
            });
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<GroupMember>());
        }

        /// <summary>
        /// 获取bot账号的资料
        /// </summary>
        /// <returns></returns>
        public async Task<Profile> GetBotProfile()
        {
            var response = await _bot.Get("botProfile");
            var result = response
                .ToJObject();

            return result.ToObject<Profile>();
        }

        /// <summary>
        /// 获取好友的资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Profile> GetFriendProfile(string id)
        {
            var response = await _bot.Get("friendProfile", new[]
            {
                ("target", id)
            });
            var result = response
                .ToJObject();

            return result.ToObject<Profile>();
        }

        /// <summary>
        /// 获取好友的资料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Profile> GetFriendProfile(Friend friend) => await GetFriendProfile(friend.Id);
        
        /// <summary>
        /// 获取群员的资料
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<Profile> GetGroupMemberProfile(string groupId, string memberId)
        {
            var response = await _bot.Get("memberProfile", new[]
            {
                ("target", groupId),
                ("memberId", memberId),
            });
            var result = response
                .ToJObject();

            return result.ToObject<Profile>();
        }

        /// <summary>
        /// 获取群员的资料
        /// </summary>
        /// <param name="groupMember"></param>
        /// <returns></returns>
        public async Task<Profile> GetGroupMemberProfile(GroupMember groupMember) =>
            await GetGroupMemberProfile(groupMember.Group.Id, groupMember.Id);

        /// <summary>
        /// 删除bot的某好友
        /// </summary>
        /// <param name="target"></param>
        public async Task DeleteFriend(string target)
        {
            var payload = new
            {
                target
            }.ToJsonString();

            await _bot.PostJson("deleteFriend", payload);
        }

        /// <summary>
        /// 处理添加好友请求
        /// </summary>
        /// <param name="args"></param>
        /// <param name="operate"></param>
        /// <param name="replyMessage"></param>
        public async void HandleFriendRequest(NewFriendRequestEventArgs args, NewFriendRequestOperate operate, string replyMessage = "")
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
    }
}