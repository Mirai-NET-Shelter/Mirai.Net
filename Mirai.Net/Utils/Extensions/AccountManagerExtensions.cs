using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions
{
    public static class AccountManagerExtensions
    {
        internal static async Task<IEnumerable<T>> GetCollection<T>(this AccountManager manager, 
            HttpEndpoints endpoints, 
            params (string, string)[] extraParameters)
        {
            var raw = await manager.Bot.GetHttp(endpoints, extraParameters);

            return raw.ToJArray().Select(x => x.ToObject<T>());
        }
    }
}