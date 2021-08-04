using System;
using System.Net.Http;
using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using AHpx.Extensions.Utils;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http;
using Websocket.Client;

namespace Mirai.Net.Utils.Extensions
{
    public static class MiraiBotExtensions
    {
        /// <summary>
        ///     拓展方法，获取MiraiBot类所需要的http请求的url
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoint">端点</param>
        /// <returns></returns>
        internal static string GetUrl(this MiraiBot bot, HttpEndpoints endpoint)
        {
            return $"http://{bot.Address}/{endpoint.GetDescription()}";
        }

        /// <summary>
        ///     拓展方法，获取MiraiBot类所需要的websocket请求的url
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="endpoint">端点</param>
        /// <returns></returns>
        internal static string GetUrl(this MiraiBot bot, WebsocketEndpoints endpoint)
        {
            return $"ws://{bot.Address}/{endpoint.GetDescription()}?verifyKey={bot.VerifyKey}&qq={bot.QQ}";
        }

        /// <summary>
        ///     拓展方法，确保MiraiBot类内部进行的http请求正常，否则抛出异常
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="responseMessage">HttpClient响应消息</param>
        /// <exception cref="Exception"></exception>
        internal static async void EnsureSuccess(this MiraiBot bot, HttpResponseMessage responseMessage)
        {
            responseMessage.EnsureSuccessStatusCode();

            var content = await responseMessage.FetchContent();

            if (content.ToJObject().ContainsKey("code"))
                if (content.Fetch("code") != "0")
                {
                    var message = content.ToJObject().ContainsKey("msg")
                        ? $"{content.Fetch("msg")}\n{bot}"
                        : $"请求失败: {bot}";

                    throw new Exception(message);
                }
        }

        /// <summary>
        ///     确保请求http请求返回了正确的状态码
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="content"></param>
        /// <exception cref="Exception"></exception>
        internal static void EnsureSuccess(this MiraiBot bot, string content)
        {
            if (content.ToJObject().ContainsKey("code"))
                if (content.Fetch("code") != "0")
                {
                    var message = content.ToJObject().ContainsKey("msg")
                        ? $"{content.Fetch("msg")}\n{bot}"
                        : $"请求失败: {bot}";

                    throw new Exception(message);
                }
        }

        /// <summary>
        ///     拓展方法，确保MiraiBot类内部建立的websocket连接正常，否则抛出异常
        /// </summary>
        /// <param name="bot"></param>
        /// <param name="responseMessage"></param>
        /// <exception cref="Exception"></exception>
        internal static void EnsureSuccess(this MiraiBot bot, ResponseMessage responseMessage)
        {
            if (responseMessage.MessageType == WebSocketMessageType.Text)
            {
                var content = responseMessage.Text.Fetch("data");

                if (content.ToJObject().ContainsKey("code"))
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
        ///     拓展方法，获取mirai-api-http插件的版本，此方法不需要经过任何认证
        /// </summary>
        /// <returns></returns>
        public static async Task<string> GetPluginVersion(this MiraiBot bot)
        {
            var url = bot.GetUrl(HttpEndpoints.About);

            try
            {
                var response = await HttpUtilities.GetAsync(url);

                bot.EnsureSuccess(response);

                var content = await response.FetchContent();
                return content.Fetch("data.version");
            }
            catch (Exception e)
            {
                throw new Exception($"获取失败: {e.Message}\n{bot}");
            }
        }

        /// <summary>
        ///     拓展方法, 获取注入mirai bot的管理器
        /// </summary>
        /// <param name="bot"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetManager<T>(this MiraiBot bot) where T : new()
        {
            return new();
        }

        /// <summary>
        /// 寻找指定类型，并且转换
        /// </summary>
        public static IObservable<TSource> WhereAndCast<TSource>(this IObservable<object> observable, Func<object, bool> predicate) where TSource : class
        {
            return observable.Where(x => predicate.Invoke(x as TSource)).Cast<TSource>();
        }
        
        /// <summary>
        /// 寻找指定类型，并且转换
        /// </summary>
        /// <param name="observable"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IObservable<TSource> WhereAndCast<TSource>(this IObservable<object> observable) where TSource : class
        {
            return observable.Where(x => x is TSource).Cast<TSource>();
        }
    }
}