using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mirai.Net.Data.Events;

namespace Mirai.Net.Utils
{
    public static class ReflectionUtilities
    {
        private static readonly List<EventBase> _eventBases = new();
        private static readonly List<Type> _eventBaseTypes = new();
        
        public static IEnumerable<EventBase> GetDefaultEventBaseInstances()
        {
            if (_eventBases.Count != 0) return _eventBases;

            var types = GetEventBaseTypes();
                
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type) as EventBase;
                _eventBases.Add(instance);
            }

            return _eventBases;
        }

        public static IEnumerable<Type> GetEventBaseTypes()
        {
            if (_eventBaseTypes.Count != 0) return _eventBaseTypes;
            
            var assembly = Assembly.GetExecutingAssembly();
            _eventBaseTypes.AddRange(assembly.GetTypes()
                .Where(x => x.Namespace!.Contains("Mirai.Net.Data.Events.Concretes")));

            return _eventBaseTypes;
        }
    }
}