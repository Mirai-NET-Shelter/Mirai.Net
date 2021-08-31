using System;
using System.Threading.Tasks;
using Flurl.Http;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Utils
{
    internal static class MiraiHttpUtils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="json"></param>
        /// <param name="withSessionKey">加入Authentication: session xxx 请求头</param>
        /// <returns></returns>
        internal static async Task<string> PostJsonAsync(string url, object json, bool withSessionKey = true)
        {
            var result = withSessionKey
                ? await url
                    .WithHeader("Authorization", $"session {MiraiBot.Instance.HttpSessionKey}")
                    .PostJsonAsync(json)
                : await url.PostJsonAsync(json);

            return await result.GetStringAsync();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="json"></param>
        /// <param name="withSessionKey">加入Authentication: session xxx 请求头</param>
        /// <returns></returns>
        internal static async Task<string> PostJsonAsync(this HttpEndpoints endpoint, object json, bool withSessionKey = true)
        {
            var url = $"http://{MiraiBot.Instance.Address}/{endpoint.GetDescription()}";

            return await PostJsonAsync(url, json, withSessionKey);
        }
    }
}