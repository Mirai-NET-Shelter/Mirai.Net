using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mirai.Net.Data.Events;

namespace Mirai.Net.Utils
{
    public static class ReflectionUtilities
    {
        private static readonly List<EventBase> EventBases;
        private static readonly List<Type> EventBaseTypes;

        static ReflectionUtilities()
        {
            EventBases = new List<EventBase>();
            EventBaseTypes = new List<Type>();
        }

        public static IEnumerable<EventBase> GetDefaultEventBaseInstances()
        {
            if (EventBases.Count != 0) return EventBases;

            var types = GetEventBaseTypes();
                
            foreach (var type in types)
            {
                if (!type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type) as EventBase;
                    EventBases.Add(instance);
                }
            }

            return EventBases;
        }

        public static IEnumerable<Type> GetEventBaseTypes()
        {
            if (EventBaseTypes.Count != 0) return EventBaseTypes;
            
            var assembly = Assembly.GetExecutingAssembly();
            var all = assembly.GetTypes();

            EventBaseTypes.AddRange(all
                .Where(x => x.FullName.Contains("Mirai.Net.Data.Events.Concretes")));

            return EventBaseTypes;
        }
    }
}