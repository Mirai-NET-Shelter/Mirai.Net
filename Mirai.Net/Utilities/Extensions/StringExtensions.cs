﻿using System;
using Mirai.Net.Sessions;
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

        public static string GetUrl(this MiraiSession session)
        {
            return $"http://{session.Host}:{session.Port}";
        }
    }
}