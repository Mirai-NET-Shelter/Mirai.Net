using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Newtonsoft.Json;

namespace Mirai.Net.Sessions.Http.Managers
{
    /// <summary>
    /// 账号管理器
    /// </summary>
    public class AccountManager
    {
        #region Private helpers

        private async Task<IEnumerable<T>> GetCollection<T>(HttpEndpoints endpoints, object extra = null)
        {
            var raw = await endpoints.GetAsync(extra);
            raw = raw.Fetch("data");

            return raw.ToJArray().Select(x => x.ToObject<T>());
        }

        private async Task<Profile> GetProfile(HttpEndpoints endpoints, object extra = null)
        {
            var raw = await endpoints.GetAsync(extra);

            return JsonConvert.DeserializeObject<Profile>(raw);
        }

        #endregion

        #region Exposed

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
            return await this.GetCollection<Member>(HttpEndpoints.MemberList, new
            {
                target
            });
        }
        
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="target"></param>
        public async Task DeleteFriend(string target)
        {
            _ = await HttpEndpoints.DeleteFriend.PostJsonAsync(new
            {
                target
            });
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
            return await this.GetProfile(HttpEndpoints.FriendProfile, new
            {
                target
            });
        }
        
        /// <summary>
        ///     获取群员资料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="target">群号</param>
        public async Task<Profile> GetMemberProfile(string id, string target)
        {
            return await this.GetProfile(HttpEndpoints.MemberProfile, new
            {
                target,
                member = id
            });
        }

        #endregion
    }
}