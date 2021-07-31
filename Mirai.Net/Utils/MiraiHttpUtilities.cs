using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Utils
{
    public static class MiraiHttpUtilities
    {
        internal static async Task<string> GetHttp(this MiraiBot bot, HttpEndpoints endpoints)
        {
            var url = $"{bot.GetUrl(endpoints)}?sessionKey={bot.HttpSessionKey}";
            
            using var client = new HttpClient();
            var raw = await client.GetAsync(url);
            
            raw.EnsureSuccessStatusCode();

            try
            {
                await bot.EnsureSuccess(raw);

                var content = await raw.FetchContent();
                var json = content.Fetch("data");

                return json;
            }
            catch (Exception e)
            {
                throw new Exception($"请求失败: {url}", e);
            }
        }
    }
}