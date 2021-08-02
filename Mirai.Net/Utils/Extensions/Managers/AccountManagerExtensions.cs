using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Concretes;
using Newtonsoft.Json;

namespace Mirai.Net.Utils.Extensions.Managers
{
    internal static class AccountManagerExtensions
    {
        internal static async Task<IEnumerable<T>> GetCollection<T>(this AccountManager manager,
            HttpEndpoints endpoints,
            params (string, string)[] extraParameters)
        {
            var raw = await manager.Bot.GetHttp(endpoints, parameters: extraParameters);

            return raw.ToJArray().Select(x => x.ToObject<T>());
        }

        internal static async Task<Profile> GetProfile(this AccountManager manager, HttpEndpoints endpoints,
            params (string, string)[] extraParameters)
        {
            var raw = await manager.Bot.GetHttp(endpoints, true, extraParameters);

            return JsonConvert.DeserializeObject<Profile>(raw);
        }
    }
}