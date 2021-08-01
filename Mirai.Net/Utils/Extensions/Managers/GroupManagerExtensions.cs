using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions.Managers
{
    public static class GroupManagerExtensions
    {
        internal static async Task SendOperate(this GroupManager manager, HttpEndpoints endpoints, object payload)
        {
            var response = await manager.Bot.PostHttp(endpoints, payload, true);

            manager.Bot.EnsureSuccess(response);
        }

        public static async Task<IEnumerable<Member>> GetMembers(this GroupManager manager, string group)
        {
            return await manager.Bot.GetManager<AccountManager>().GetGroupMembers(group);
        }

        public static async Task<IEnumerable<Member>> GetMembers(this GroupManager manager, long group)
        {
            return await manager.Bot.GetManager<AccountManager>().GetGroupMembers(group);
        }

        public static async Task<IEnumerable<Group>> GetGroups(this GroupManager manager)
        {
            return await manager.Bot.GetManager<AccountManager>().GetGroups();
        }

        public static async Task<Profile> GetMemberProfile(this GroupManager manager, string id, string target)
        {
            return await manager.Bot.GetManager<AccountManager>().GetMemberProfile(id, target);
        }

        public static async Task<Profile> GetMemberProfile(this GroupManager manager, long id, long target)
        {
            return await manager.Bot.GetManager<AccountManager>().GetMemberProfile(id, target);
        }
    }
}