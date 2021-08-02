using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mirai.Net.Utils
{
    internal class ReflectionUtilities<T> where T : class
    {
        private readonly List<T> _list = new();
        private readonly List<Type> _types = new();

        internal IEnumerable<T> GetDefaultInstances(string location, ref List<Type> types)
        {
            if (_list.Count != 0) return _list;

            if (_types.Count != 0) types = _types;

            var assembly = Assembly.GetExecutingAssembly();
            var all = assembly.GetTypes();

            types.AddRange(all
                .Where(x => x.FullName!.Contains(location)));

            foreach (var type in types)
                if (!type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type) as T;
                    _list.Add(instance);
                }

            return _list.Where(x => x != null);
        }
    }
}