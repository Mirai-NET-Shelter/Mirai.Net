using System;
using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Messages;
using Newtonsoft.Json;

namespace Mirai.Net.Utils.Extensions
{
    internal static class MessageExtensions
    {
        private static List<Type> _eventTypes = new();
        private static List<EventBase> _events = new();

        private static List<MessageReceiverBase> _messageReceivers = new();
        private static List<Type> _messageReceiversTypes = new();

        private static List<MessageBase> _messageBases = new();
        private static List<Type> _messageBasesTypes = new();

        /// <summary>
        ///     根据raw json转换成EventBase，十分酷哥的反射
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        internal static EventBase GetEventBase(this string json)
        {
            if (_events.Count == 0)
            {
                var utilities = new ReflectionUtilities<EventBase>();

                _events = utilities
                    .GetDefaultInstances("Mirai.Net.Data.Events.Concretes", ref _eventTypes)
                    .ToList();
            }

            var root = JsonConvert.DeserializeObject<EventBase>(json);

            if (_events.Any(x => x.Type == root!.Type))
            {
                var instance = _events.First(x => x.Type == root!.Type);

                foreach (var type in _eventTypes)
                    if (instance.GetType() == type)
                        return JsonConvert.DeserializeObject(json, type) as EventBase;
            }

            throw new Exception($"错误的json: {json}");
        }

        internal static MessageReceiverBase GetMessageReceiverBase(this string json)
        {
            if (_messageReceivers.Count == 0)
            {
                var utilities = new ReflectionUtilities<MessageReceiverBase>();

                _messageReceivers = utilities
                    .GetDefaultInstances("Mirai.Net.Data.Messages.Receivers", ref _messageReceiversTypes)
                    .ToList();
            }

            var root = JsonConvert.DeserializeObject<MessageReceiverBase>(json);

            if (_messageReceivers.Any(x => x.Type == root!.Type))
            {
                var instance = _messageReceivers.First(x => x.Type == root!.Type);

                foreach (var type in _messageReceiversTypes)
                    if (instance.GetType() == type)
                        return JsonConvert.DeserializeObject(json, type) as MessageReceiverBase;
            }

            throw new Exception($"错误的json: {json}");
        }

        internal static MessageBase GetMessageBase(this string json)
        {
            if (_messageBases.Count == 0)
            {
                var utilities = new ReflectionUtilities<MessageBase>();

                _messageBases = utilities
                    .GetDefaultInstances("Mirai.Net.Data.Messages.Concretes", ref _messageBasesTypes)
                    .ToList();
            }

            var root = JsonConvert.DeserializeObject<MessageBase>(json);

            if (_messageBases.Any(x => x.Type == root!.Type))
            {
                var instance = _messageBases.First(x => x.Type == root!.Type);

                foreach (var type in _messageBasesTypes)
                    if (instance.GetType() == type)
                        return JsonConvert.DeserializeObject(json, type) as MessageBase;
            }

            throw new Exception($"错误的json: {json}");
        }
    }
}