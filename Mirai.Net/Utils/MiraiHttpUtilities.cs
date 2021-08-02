using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Utils
{
    internal static class MiraiHttpUtilities
    {
        /// <summary>
        ///     发送http get请求到指定的url
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="url"></param>
        /// <param name="direct">没有data键的数据</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static async Task<string> GetHttp(this MiraiBot bot, string url, bool direct = false)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("sessionKey", bot.HttpSessionKey);

            var raw = await client.GetAsync(url);

            var content = await raw.FetchContent();

            try
            {
                bot.EnsureSuccess(raw);

                var json = direct ? content : content.Fetch("data");

                return json;
            }
            catch (Exception e)
            {
                throw new Exception($"请求失败: {url}", e);
            }
        }

        /// <summary>
        ///     发送http get请求到指定的端点并
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoints"></param>
        /// <param name="direct">没有data键的数据</param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal static async Task<string> GetHttp(this MiraiBot bot, HttpEndpoints endpoints, bool direct = false,
            params (string, string)[] parameters)
        {
            var url = $"{bot.GetUrl(endpoints)}{ParseParameters(parameters)}";

            return await bot.GetHttp(url, direct);
        }

        internal static async Task<string> PostHttp(this MiraiBot bot, string url, object json, bool direct = false)
        {
            if (json is not string) json = json.ToJsonString();

            var payload = json.ToString();
            using var client = new HttpClient();
            var body = new StringContent(payload, Encoding.Default, "application/json");

            client.DefaultRequestHeaders.Add("sessionKey", bot.HttpSessionKey);

            var response = await client.PostAsync(url, body);

            var content = await response.FetchContent();

            try
            {
                bot.EnsureSuccess(response);

                var re = direct ? content : content.Fetch("data");

                return re;
            }
            catch (Exception e)
            {
                throw new Exception($"请求失败: {url}\n{json}", e);
            }
        }

        internal static async Task<string> PostHttp(this MiraiBot bot, HttpEndpoints endpoints, object json,
            bool direct = false, params (string, string)[] parameters)
        {
            var url = $"{bot.GetUrl(endpoints)}{ParseParameters(parameters)}";

            return await bot.PostHttp(url, json, direct);
        }

        internal static async Task<string> PostFileHttp(this MiraiBot bot, HttpEndpoints endpoints, FileInfo file,
            string fileParameterName, bool direct = false, params (string, string)[] extraParams)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("sessionKey", bot.HttpSessionKey);

            using var request = new HttpRequestMessage();
            using var content = new MultipartFormDataContent();

            using var stream = file.OpenRead();
            content.Add(new StreamContent(stream), fileParameterName, file.Name);

            foreach (var (key, value) in extraParams) content.Add(new StringContent(value), key);

            var url = $"{bot.GetUrl(endpoints)}";

            var response = await client.PostAsync(url, content);

            try
            {
                bot.EnsureSuccess(response);

                var fetch = await response.FetchContent();
                var re = direct ? fetch : fetch.Fetch("data");

                return re;
            }
            catch (Exception e)
            {
                throw new Exception($"请求失败:{url}\r\n", e);
            }
        }

        internal static string ParseParameters(params (string, string)[] parameters)
        {
            var ps = parameters.ToList();
            var url = string.Empty;

            if (ps.Count != 0)
            {
                url += $"?{ps[0].Item1}={ps[0].Item2}";

                ps.Remove(ps.First());

                var result = ps.Select(x => $"&{x.Item1}={x.Item2}").ToArray();
                var suffix = string.Join(string.Empty, result);

                url += suffix;
            }

            return url;
        }
    }
}