using System;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Flurl.Http;
using Mirai.Net.Data.Exceptions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Utils
{
    internal static class MiraiHttpUtils
    {
        #region Http requests

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

        #endregion

        #region Guarantee

        /// <summary>
        /// 根据json判断这个json是否是正确的，否则抛出异常
        /// </summary>
        /// <param name="json"></param>
        /// <param name="appendix"></param>
        internal static void EnsureSuccess(this string json, string appendix = null)
        {
            var obj = json.ToJObject();

            if (obj.ContainsKey("code"))
            {
                var code = obj.Fetch("code");
                if (code != "0")
                {
                    var message = $"原因: {code.OfErrorMessage()}";

                    if (appendix.IsNotNullOrEmpty())
                        message += $"\r\n备注: {appendix}";
                    else
                        message += $"\r\n备注: {MiraiBot.Instance.ToJsonString()}";

                    throw new InvalidResponseException(message);
                }
            }
        }

        #endregion
    }
}