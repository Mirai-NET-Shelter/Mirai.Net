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
    public static class AccountManager
    {
        #region Private helpers

        private static async Task<IEnumerable<T>> GetCollection<T>(HttpEndpoints endpoints, object extra = null)
        {
            var raw = await endpoints.GetAsync(extra);
            raw = raw.Fetch("data");

            return raw.ToJArray().Select(x => x.ToObject<T>());
        }

        private static async Task<Profile> GetProfile(HttpEndpoints endpoints, object extra = null)
        {
            var raw = await endpoints.GetAsync(extra);

            return JsonConvert.DeserializeObject<Profile>(raw);
        }

        #endregion

        #region Exposed

        /// <summary>
        ///     获取bot账号的好友列表
        /// </summary>
        public static async Task<IEnumerable<Friend>> GetFriends()
        {
            return await GetCollection<Friend>(HttpEndpoints.FriendList);
        }
        
        /// <summary>
        ///     获取bot账号的QQ群列表
        /// </summary>
        public static async Task<IEnumerable<Group>> GetGroups()
        {
            return await GetCollection<Group>(HttpEndpoints.GroupList);
        }
        
        /// <summary>
        ///     获取某群的全部群成员
        /// </summary>
        public static async Task<IEnumerable<Member>> GetGroupMembers(string target)
        {
            return await GetCollection<Member>(HttpEndpoints.MemberList, new
            {
                target
            });
        }
        
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="target"></param>
        public static async Task DeleteFriend(string target)
        {
            _ = await HttpEndpoints.DeleteFriend.PostJsonAsync(new
            {
                target
            });
        }

        /// <summary>
        ///     获取bot资料
        /// </summary>
        public static async Task<Profile> GetBotProfile()
        {
            return await GetProfile(HttpEndpoints.BotProfile);
        }
        
        /// <summary>
        ///     获取好友资料
        /// </summary>
        public static async Task<Profile> GetFriendProfile(string target)
        {
            return await GetProfile(HttpEndpoints.FriendProfile, new
            {
                target
            });
        }
        
        /// <summary>
        ///     获取群员资料
        /// </summary>
        /// <param name="id"></param>
        /// <param name="target">群号</param>
        public static async Task<Profile> GetMemberProfile(string id, string target)
        {
            return await GetProfile(HttpEndpoints.MemberProfile, new
            {
                target,
                member = id
            });
        }

        #endregion
    }
}