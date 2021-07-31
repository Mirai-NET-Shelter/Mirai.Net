using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// 发送http get请求到指定的url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private static async Task<string> GetHttp(this MiraiBot bot, string url)
        {
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
        
        /// <summary>
        /// 发送http get请求到指定的端点
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoints"></param>
        /// <returns></returns>
        internal static async Task<string> GetHttp(this MiraiBot bot, HttpEndpoints endpoints)
        {
            var url = $"{bot.GetUrl(endpoints)}?sessionKey={bot.HttpSessionKey}";

            return await bot.GetHttp(url);
        }

        /// <summary>
        /// 发送http get请求到指定的端点并
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoints"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal static async Task<string> GetHttp(this MiraiBot bot, HttpEndpoints endpoints, params (string, string)[] parameters)
        {
            var url = bot.GetUrl(endpoints);
            var ps = parameters.ToList();

            if (ps.All(x => x.Item1 != "sessionKey"))
            {
                ps.Add(("sessionKey", bot.HttpSessionKey));
            }

            if (ps.Count != 0)
            {
                url += $"?{ps[0].Item1}={ps[0].Item2}";

                ps.Remove(ps.First());

                var result = ps.Select(x => $"&{x.Item1}={x.Item2}").ToArray();
                var suffix = string.Join(string.Empty, result);

                url += suffix;
            }

            return await bot.GetHttp(url);
        }
    }
}