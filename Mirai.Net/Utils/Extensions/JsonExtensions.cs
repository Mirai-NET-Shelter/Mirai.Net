using Newtonsoft.Json.Linq;

namespace Mirai.Net.Utils.Extensions
{
    /// <summary>
    /// 关于json操作的拓展方法集
    /// </summary>
    public static class JsonExtensions
    {
        /// <summary>
        /// 从JToken里取出指定key的值，JObject和JArray都继承自JToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string Fetch(this JToken token, string key)
        {
            var value = token[key].ToString();

            return value;
        }

        /// <summary>
        /// 把一个json格式的字符串转换成JObject
        /// </summary>
        /// <param name="primitive"></param>
        /// <returns></returns>
        public static JObject ToJObject(this string primitive)
        {
            return JObject.Parse(primitive);
        }

        /// <summary>
        /// 把一个json数组格式的字符串转换成JArray
        /// </summary>
        /// <param name="primitive"></param>
        /// <returns></returns>
        public static JArray ToJArray(this string primitive)
        {
            return JArray.Parse(primitive);
        }
    }
}