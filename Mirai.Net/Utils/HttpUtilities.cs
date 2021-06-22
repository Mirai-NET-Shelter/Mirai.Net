using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mirai.Net.Utils
{
    public static class HttpUtilities
    {
        /// <summary>
        /// 发送一个Get请求到指定的url
        /// </summary>
        /// <returns></returns>
        public static async Task<string> Get(string url)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(url);

            return await response.Content.ReadAsStringAsync();
        }
    }
}