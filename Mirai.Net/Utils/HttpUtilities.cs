using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Utils
{
    internal static class HttpUtilities
    {
        /// <summary>
        /// 发送一个Get请求到指定的url，如果失败则抛出异常
        /// </summary>
        /// <returns></returns>
        internal static async Task<string> Get(string url)
        {
            using var client = new HttpClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// post一个json体到指定的url
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        internal static async Task<string> PostJson(string url, string json)
        {
            using var client = new HttpClient();
            var content = new StringContent(json, Encoding.Default, "application/json");

            var response = await client.PostAsync(url, content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
        
        /// <summary>
        /// MiraiBot类的拓展方法，直接在请求头添加sessionKey
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoint"></param>
        /// <param name="json"></param>
        /// <returns></returns>
        internal static async Task<string> PostJson(this MiraiBot bot, string endpoint, string json)
        {
            using var client = new HttpClient();
            var url = $"http://{bot.Address}/{endpoint}";
            var content = new StringContent(json, Encoding.Default, "application/json");

            client.DefaultRequestHeaders.Add("Authorization", $"sessionKey {bot.SessionKey}");

            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            result.EnsureSuccess();

            return result;
        }

        /// <summary>
        /// MiraiBot类的拓展方法，添加Authorization请求头
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoint"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        internal static async Task<string> Get(this MiraiBot bot, string endpoint, IEnumerable<(string, string)> parameters = null)
        {
            var url = $"http://{bot.Address}/{endpoint}?sessionKey={bot.SessionKey}";

            if (parameters != null)
                url = parameters.Aggregate(url,
                    (current, keyValuePair) => current + $"&{keyValuePair.Item1}={keyValuePair.Item2}");

            using var client = new HttpClient();

            client.DefaultRequestHeaders.Add("Authorization", $"sessionKey {bot.SessionKey}");

            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            result.EnsureSuccess();

            return result;
        }
    }
}