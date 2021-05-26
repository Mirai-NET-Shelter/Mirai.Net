using System;
using Newtonsoft.Json;

namespace Mirai.Net.Utilities.Extensions
{
    public static class StringExtensions
    {
        public static Uri ToUri(this string s)
        {
            try
            {
                Uri.TryCreate(s, UriKind.RelativeOrAbsolute, out var re);
                
                return re;
            }
            catch
            {
                throw new ArgumentException("Invalid uri format!");
            }
        }

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