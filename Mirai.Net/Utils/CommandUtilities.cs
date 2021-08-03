using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mirai.Net.Modules;

namespace Mirai.Net.Utils
{
    public static class CommandUtilities
    {
        /// <summary>
        /// 加载指定命名空间的命令模块
        /// </summary>
        public static IEnumerable<ICommandModule> LoadCommandModules(string space)
        {
            var assembly = Assembly.GetEntryAssembly();
            var types = assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && !x.IsInterface)
                .Where(x => x.GetInterfaces().Any(x => x == typeof(ICommandModule)))
                .Where(x => x!.FullName!.Contains(space))
                .ToList();

            foreach (var type in types)
            {
                yield return Activator.CreateInstance(type) as ICommandModule;
            }
        }

        /// <summary>
        /// 加载与某模块同命名空间的所有模块
        /// </summary>
        /// <typeparam name="T">某模块</typeparam>
        /// <returns></returns>
        public static IEnumerable<ICommandModule> LoadCommandModules<T>() where T : ICommandModule
        {
            var basic = typeof(T);
            
            var types = Assembly.GetAssembly(basic).GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && !x.IsInterface)
                .Where(x => x.GetInterfaces().Any(x => x == typeof(ICommandModule)))
                .Where(x => x!.FullName!.Contains(basic.Namespace!))
                .ToList();
            
            foreach (var type in types)
            {
                yield return Activator.CreateInstance(type) as ICommandModule;
            }
        }
    }
}