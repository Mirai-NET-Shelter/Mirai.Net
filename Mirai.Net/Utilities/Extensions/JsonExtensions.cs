using System;
using Newtonsoft.Json;

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
    }
}