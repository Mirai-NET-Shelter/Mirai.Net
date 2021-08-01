using System;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Sessions.Http.Concretes;

namespace Mirai.Net.Utils.Extensions
{
    public static class MessageManagerExtensions
    {
        /// <summary>
        /// 确保返回的状态码是成功的
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="response"></param>
        /// <exception cref="Exception"></exception>
        public static void EnsureSuccess(this MessageManager manager, string response)
        {
            var json = response.ToJObject();

            if (json.ContainsKey("code"))
            {
                if (json.Fetch("code") != "0")
                {
                    var message = json.ContainsKey("msg")
                        ? $"{json.Fetch("msg")}\n{manager}"
                        : $"发送失败: {manager}";

                    throw new Exception(message);
                }
            }
        }

        internal static async Task<string> SendMessage(this MessageManager manager, HttpEndpoints endpoints, object payload)
        {
            var response = await manager.Bot.PostHttp(endpoints, payload, true);
            manager.EnsureSuccess(response);

            return response.Fetch("messageId");
        }
        
        internal static async Task<string> SendOperate(this MessageManager manager, HttpEndpoints endpoints, object payload)
        {
            var response = await manager.Bot.PostHttp(endpoints, payload, true);
            manager.EnsureSuccess(response);

            return response;
        }
    }
}