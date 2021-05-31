using System;
using Mirai.Net.Sessions;
using Newtonsoft.Json;

namespace Mirai.Net.Utilities.Extensions
{
    internal static class StringExtensions
    {
        internal static Uri ToUri(this string s)
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

        internal static string GetUrl(this MiraiSession session, bool isWebsocket = false)
        {
            var prefix = isWebsocket ? "ws" : "http";

            return $"{prefix}://{session.Host}:{session.Port}";
        }

        internal static bool IsNumber(this string s)
        {
            return int.TryParse(s, out _);
        }

        /// <summary>
        /// Message: ture, Event: false
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static bool GetReceivedType(this string s)
        {
            try
            {
                return s.ToJObject().GetPropertyValue("type").Contains("Message");
            }
            catch
            {
                throw new Exception("Invalid json!");
            }
        }
    }
}