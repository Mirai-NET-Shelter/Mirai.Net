using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Utilities.Extensions
{
    public static class JsonExtensions
    {
        public static string ToJson<T>(this T type)
        {
            try
            {
                return JsonConvert.SerializeObject(type);
            }
            catch
            {
                throw new ArgumentException("This type can't be a json entity!");
            }
        }

        public static T ToObject<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch
            {
                throw new ArgumentException($"{json}\nIs not a valid json!");
            }
        }

        public static string GetPropertyValue(this JObject obj, string propertyName)
        {
            try
            {
                return obj[propertyName].ToString();
            }
            catch
            {
                throw new ArgumentException($"{propertyName}\nNo such property!");
            }
        }
        
        public static string GetPropertyValue(this JToken obj, string propertyName)
        {
            try
            {
                return obj[propertyName].ToString();
            }
            catch
            {
                throw new ArgumentException($"{propertyName}\nNo such property!");
            }
        }

        public static JObject ToJObject(this object ex)
        {
            try
            {
                return JObject.Parse(ex.ToString()!);
            }
            catch
            {
                throw new ArgumentException($"{ex}\nIs not a valid json!");
            }
        }
    }
}