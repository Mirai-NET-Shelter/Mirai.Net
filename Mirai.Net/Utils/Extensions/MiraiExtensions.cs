using System;
using System.Linq;

namespace Mirai.Net.Utils.Extensions
{
    public static class MiraiExtensions
    {
        /// <summary>
        /// 根据mirai-http-api的响应json来判断对应请求是否成功。
        /// </summary>
        /// <param name="s">mirai的api响应json</param>
        public static void EnsureSuccess(this string s)
        {
            var obj = s.ToJObject();

            try
            {
                var code = obj.Fetch("code");

                if (code != "0")
                {
                    throw new Exception(obj.Fetch("msg"));
                }
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("没有与此path:"))
                {
                    throw;
                }
            }
        }
    }
}