using System;
using System.Collections.Generic;
using System.Linq;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;

namespace Mirai.Net.Utils.Internal
{
    public static class ExceptionUtils
    {
        /// <summary>
        /// 获取状态码对应的原因
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        internal static string OfErrorMessage(this string json)
        {
            var code = json.Fetch("code").IsIntegerOrThrow(new ArgumentException("错误的状态码"));

            var vocabulary = new Dictionary<string, string>
            {
                { "0", "正确" },
                { "1", "错误的verify key" },
                { "2", "指定的Bot不存在" },
                { "3", "Session失效或不存在" },
                { "4", "Session未认证(未激活)" },
                { "5", "发送消息目标不存在(指定对象不存在)" },
                { "6", "指定文件不存在" },
                { "10", "Bot没有对应操作的限权" },
                { "20", "Bot被禁言" },
                { "30", "消息过长" },
                { "400", "错误的访问" },
                { "500", "上传文件错误" }
            };

            return vocabulary.FirstOrDefault(x => x.Key == code).Value;
        }
    }
}