using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions.Managers
{
    internal static class FileManagerExtensions
    {
        internal static async Task<string> SendGet(this FileManager manager, HttpEndpoints endpoints, string group,
            string id = "")
        {
            var payload = new[]
            {
                ("id", id), ("group", group)
            };

            var response = await manager.Bot.GetHttp(endpoints, parameters: payload);

            return response;
        }
    }
}