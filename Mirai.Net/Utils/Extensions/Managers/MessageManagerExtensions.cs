using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions.Managers
{
    internal static class MessageManagerExtensions
    {
        internal static async Task<string> SendMessage(this MessageManager manager, HttpEndpoints endpoints,
            object payload)
        {
            var response = await manager.Bot.PostHttp(endpoints, payload, true);
            manager.Bot.EnsureSuccess(response);

            return response.Fetch("messageId");
        }

        internal static async Task<string> SendOperate(this MessageManager manager, HttpEndpoints endpoints,
            object payload)
        {
            var response = await manager.Bot.PostHttp(endpoints, payload, true);
            manager.Bot.EnsureSuccess(response);


            return response;
        }
    }
}