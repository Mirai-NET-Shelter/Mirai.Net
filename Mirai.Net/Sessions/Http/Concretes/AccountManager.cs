using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class AccountManager
    {
        internal readonly MiraiBot Bot;

        public AccountManager(MiraiBot bot)
        {
            Bot = bot;
        }
        
        /// <summary>
        /// 获取bot账号的好友列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Friend>> GetFriends()
        {
            return await this.GetCollection<Friend>(HttpEndpoints.FriendList);
        }

        /// <summary>
        /// 获取bot账号的QQ群列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Group>> GetGroups()
        {
            return await this.GetCollection<Group>(HttpEndpoints.GroupList);
        }

        /// <summary>
        /// 获取某群的全部群成员
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Member>> GetGroupMembers(string target)
        {
            return await this.GetCollection<Member>(HttpEndpoints.MemberList, ("target", target));
        }

        /// <summary>
        /// 获取某群的全部群成员
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Member>> GetGroupMembers(long target) => await GetGroupMembers(target.ToString());
    }
}