using System;
using System.Net.Http;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using AHpx.Extensions.Utils;
using Mirai.Net.Sessions;

namespace Mirai.Net.Utils.Extensions
{
    public static class MiraiBotExtensions
    {
        /// <summary>
        /// 拓展方法，获取MiraiBot类所需要的http请求的url
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoint">端点</param>
        /// <returns></returns>
        internal static string GetUrl(this MiraiBot bot, string endpoint)
        {
            return $"http://{bot.Address}/{endpoint}";
        }

        /// <summary>
        /// 拓展方法，确保MiraiBot类内部进行的http请求正常，否则抛出异常
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="responseMessage">HttpClient响应消息</param>
        /// <exception cref="Exception"></exception>
        internal static async Task EnsureSuccess(this MiraiBot bot, HttpResponseMessage responseMessage)
        {
            responseMessage.EnsureSuccessStatusCode();

            var content = await responseMessage.FetchContent();

            if (content.ToJObject().ContainsKey("code"))
            {
                if (content.Fetch("code") != "0")
                {
                    var message = content.ToJObject().ContainsKey("msg")
                        ? $"{content.Fetch("msg")}\n{bot}"
                        : $"请求失败: {bot}";

                    throw new Exception(message);
                }
            }
        }
        
        /// <summary>
        /// 拓展方法，获取mirai-api-http插件的版本，此方法不需要经过任何认证
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetPluginVersion(this MiraiBot bot)
        {
            var url = bot.GetUrl("about");

            try
            {
                var response = await HttpUtilities.GetAsync(url);

                await bot.EnsureSuccess(response);

                var content = await response.FetchContent();
                return content.Fetch("data.version");
            }
            catch (Exception e)
            {
                throw new Exception($"获取失败: {e.Message}\n{bot}");
            }
        }
    }
}