using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Utils
{
    public static class ReflectionUtilities
    {
        private static List<EventBase> _eventBases = new ();
        private static List<Type> _eventBaseTypes = new ();

        public static IEnumerable<EventBase> GetDefaultEventBaseInstances(out List<Type> output)
        {
            output = _eventBaseTypes;
            
            return GetDefaultInstances("Mirai.Net.Data.Events.Concretes", ref _eventBases,
                ref _eventBaseTypes);
        }

        private static List<MessageBase> _messageBases = new ();
        private static List<Type> _messageBaseTypes = new ();
        public static IEnumerable<MessageBase> GetDefaultMessageBaseInstances(out List<Type> output)
        {
            output = _messageBaseTypes;
            
            return GetDefaultInstances("Mirai.Net.Data.Messages.Concretes", ref _messageBases,
                ref _messageBaseTypes);
        }
        
        private static IEnumerable<T> GetDefaultInstances<T>(string location, ref List<T> output, ref List<Type> typeOutput) where T : class
        {
            if (_eventBases.Count != 0) return output;

            var types = GetTypes(location, ref typeOutput);
                
            foreach (var type in types)
            {
                if (!type.IsAbstract)
                {
                    var instance = Activator.CreateInstance(type) as T;
                    output.Add(instance);
                }
            }

            return output;
        }

        private static IEnumerable<Type> GetTypes(string location, ref List<Type> output)
        {
            if (_eventBaseTypes.Count != 0) return _eventBaseTypes;
            
            var assembly = Assembly.GetExecutingAssembly();
            var all = assembly.GetTypes();
            
            output.AddRange(all
                .Where(x => x.FullName!.Contains(location)));

            return output;
        }
    }
}