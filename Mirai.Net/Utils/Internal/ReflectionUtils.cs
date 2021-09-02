using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mirai.Net.Utils.Internal
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// 获取某个命名空间下所有类的默认实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetDefaultInstances<T>(string @namespace) where T : class
        {
            return Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.FullName != null)
                .Where(type => type.FullName.Contains(@namespace))
                .Where(type => !type.IsAbstract)
                .Select(type => Activator.CreateInstance(type) as T);
        }
    }
}