using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Utils.Extensions
{
    /// <summary>
    /// 关于json操作的拓展方法集
    /// </summary>
    internal static class JsonExtensions
    {
        /// <summary>
        /// 从JToken里取出指定path的值，JObject和JArray都继承自JToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static string Fetch(this JToken token, string path)
        {
            try
            {
                var value = token.SelectToken(path) ?? throw new ArgumentException($"没有与此path: {path} 对应的value！");

                return value.ToString();
            }
            catch (Exception e)
            {
                throw new ArgumentException($"没有与此path: {path} 对应的value！", e);
            }
            
        }

        /// <summary>
        /// 把一个json格式的字符串转换成JObject
        /// </summary>
        /// <param name="primitive"></param>
        /// <returns></returns>
        internal static JObject ToJObject(this string primitive)
        {
            return JObject.Parse(primitive);
        }

        /// <summary>
        /// 把一个json数组格式的字符串转换成JArray
        /// </summary>
        /// <param name="primitive"></param>
        /// <returns></returns>
        internal static JArray ToJArray(this string primitive)
        {
            return JArray.Parse(primitive);
        }

        /// <summary>
        /// 将一个可序列化为json的对象转换为json文本
        /// </summary>
        /// <returns></returns>
        internal static string ToJsonString<T>(this T type, NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            try
            {
                return JsonConvert.SerializeObject(type, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = nullValueHandling
                });
            }
            catch (Exception e)
            {
                throw new ArgumentException("此对象不可以序列化！", e);
            }
        }

        /// <summary>
        /// 将一个可以json文本反序列化为指定的对象
        /// </summary>
        /// <param name="s"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal static T ToEntity<T>(this string s)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(s);
            }
            catch (Exception e)
            {
                throw new ArgumentException("此对象不可以序列化！", e);
            }
        }
    }
}