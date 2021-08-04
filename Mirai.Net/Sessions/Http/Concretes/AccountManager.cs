using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Managers;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class AccountManager
    {
        public readonly MiraiBot Bot = MiraiBotFactory.Bot;

        /// <summary>
        ///     获取bot账号的好友列表
        /// </summary>
        public async Task<IEnumerable<Friend>> GetFriends()
        {
            return await this.GetCollection<Friend>(HttpEndpoints.FriendList);
        }

        /// <summary>
        ///     获取bot账号的QQ群列表
        /// </summary>
        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await this.GetCollection<Group>(HttpEndpoints.GroupList);
        }

        /// <summary>
        ///     获取某群的全部群成员
        /// </summary>
        public async Task<IEnumerable<Member>> GetGroupMembers(string target)
        {
            return await this.GetCollection<Member>(HttpEndpoints.MemberList, ("target", target));
        }

        /// <summary>
        ///     获取某群的全部群成员
        /// </summary>
        public async Task<IEnumerable<Member>> GetGroupMembers(long target)
        {
            return await GetGroupMembers(target.ToString());
        }

        public async Task DeleteFriend(string target)
        {
            var payload = new
            {
                target
            };
            var response = await Bot.PostHttp(HttpEndpoints.DeleteFriend, payload, true);

            Bot.EnsureSuccess(response);
        }

        public async Task DeleteFriend(long target)
        {
            await DeleteFriend(target.ToString());
        }

        /// <summary>
        ///     获取bot资料
        /// </summary>
        public async Task<Profile> GetBotProfile()
        {
            return await this.GetProfile(HttpEndpoints.BotProfile);
        }

        /// <summary>
        ///     获取好友资料
        /// </summary>
        public async Task<Profile> GetFriendProfile(string target)
        {
            return await this.GetProfile(HttpEndpoints.FriendProfile, ("target", target));
        }

        /// <summary>
        ///     获取好友资料
        /// </summary>
        public async Task<Profile> GetFriendProfile(long target)
        {
            return await GetFriendProfile(target.ToString());
        }

        /// <summary>
        ///     获取群员资料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="target">群号</param>
        public async Task<Profile> GetMemberProfile(string id, string target)
        {
            return await this.GetProfile(HttpEndpoints.MemberProfile,
                ("target", target),
                ("memberId", id));
        }

        /// <summary>
        ///     获取群员资料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="target">群号</param>
        public async Task<Profile> GetMemberProfile(long id, long target)
        {
            return await GetMemberProfile(id.ToString(), target.ToString());
        }
    }
}