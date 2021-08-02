using System;
using System.ComponentModel;
using System.Linq;

namespace Mirai.Net.Utils.Extensions
{
    internal static class EnumeratedTypeExtensions
    {
        /// <summary>
        ///     获取某枚举值的Description attribute值，如果没有这个特性则直接返回该值的ToString
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        internal static string GetDescription(this Enum t)
        {
            //stackoverflow oriented programming
            //https://stackoverflow.com/questions/630803/associating-enums-with-strings-in-c-sharp

            return t
                .GetType()
                .GetField(t.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[]
                {Length: > 0} attributes
                ? attributes.First().Description
                : t.ToString();
        }
    }
}