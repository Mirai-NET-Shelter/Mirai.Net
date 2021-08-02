using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions.Managers
{
    internal static class RequestManagerExtensions
    {
        internal static async Task SendOperate(this RequestManager manager, HttpEndpoints endpoints, object payload)
        {
            var response = await manager.Bot.PostHttp(endpoints, payload, true);

            manager.Bot.EnsureSuccess(response);
        }
    }
}