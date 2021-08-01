using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
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
    }
}