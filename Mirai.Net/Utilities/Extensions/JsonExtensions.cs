using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Utilities.Extensions
{
    internal static class JsonExtensions
    {
        internal static string ToJson<T>(this T type, NullValueHandling nullValueHandling = NullValueHandling.Ignore)
        {
            try
            {
                return JsonConvert.SerializeObject(type, Formatting.Indented, new JsonSerializerSettings
                {
                    NullValueHandling = nullValueHandling
                });
            }
            catch
            {
                throw new ArgumentException("This type can't be a json entity!");
            }
        }

        internal static T ToObject<T>(this string json)
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

        internal static string GetPropertyValue(this JObject obj, string propertyName)
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
        
        internal static string GetPropertyValue(this JToken obj, string propertyName)
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

        internal static JObject ToJObject(this object ex)
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