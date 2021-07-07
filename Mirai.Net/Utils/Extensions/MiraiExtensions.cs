using System;
using System.Linq;

namespace Mirai.Net.Utils.Extensions
{
    internal static class MiraiExtensions
    {
        /// <summary>
        /// 根据mirai-http-api的响应json来判断对应请求是否成功。
        /// </summary>
        /// <param name="s">mirai的api响应json</param>
        internal static void EnsureSuccess(this string s)
        {
            var obj = s.ToJObject();

            if (obj.ContainsKey("code"))
            {
                var code = obj.Fetch("code");

                if (code != "0")
                {
                    throw new Exception(obj.Fetch("msg"));
                }
            }
        }
    }
}