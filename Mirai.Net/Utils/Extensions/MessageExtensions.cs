using System;
using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Data.Events;
using Newtonsoft.Json;

namespace Mirai.Net.Utils.Extensions
{
    public static class MessageExtensions
    {
        /// <summary>
        /// 根据raw json转换成EventBase，十分酷哥的反射
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static EventBase GetEventBase(this string json)
        {
            var types = new List<Type>();
            var utilities = new ReflectionUtilities<EventBase>();
            
            var instances = utilities
                .GetDefaultInstances("Mirai.Net.Data.Events.Concretes", ref types);
            
            var root = JsonConvert.DeserializeObject<EventBase>(json);

            if (instances.Any(x => x.Type == root!.Type))
            {
                var instance = instances.First(x => x.Type == root!.Type);

                foreach (var type in types)
                {
                    if (instance.GetType() == type)
                    {
                        return JsonConvert.DeserializeObject(json, type) as EventBase;
                    }
                }
            }

            throw new Exception($"错误的json: {json}");
        }
    }
}