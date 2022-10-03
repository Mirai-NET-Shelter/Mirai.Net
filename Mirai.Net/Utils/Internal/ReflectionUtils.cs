using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Manganese.Text;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json;

namespace Mirai.Net.Utils.Internal;

internal static class ReflectionUtils
{
    /// <summary>
    ///     获取某个命名空间下所有类的默认实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal static IEnumerable<T> GetDefaultInstances<T>(string @namespace) where T : class
    {
        return Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.FullName != null)
            .Where(type => type.FullName.Contains(@namespace))
            .Where(type => !type.IsAbstract)
            .Select(type =>
            {
                if (Activator.CreateInstance(type) is T instance)
                {
                    return instance;
                }

                return null;
            })
            .Where(i => i != null);
    }
    
    /// <summary>
    ///     默认消息接收器实例
    /// </summary>
    private static readonly IEnumerable<MessageReceiverBase> MessageReceiverBases =
        GetDefaultInstances<MessageReceiverBase>(
            "Mirai.Net.Data.Messages.Receivers");
    
    /// <summary>
    ///     默认消息实例
    /// </summary>
    private static readonly IEnumerable<MessageBase> MessageBases =
        GetDefaultInstances<MessageBase>("Mirai.Net.Data.Messages.Concretes");

    /// <summary>
    ///     默认事件实例
    /// </summary>
    private static readonly IEnumerable<EventBase> EventBases =
        GetDefaultInstances<EventBase>("Mirai.Net.Data.Events.Concretes");
    
    /// <summary>
    ///     根据json动态解析对应的消息子类
    /// </summary>
    /// <param name="data">as: {"type": "Plain", "text": "Mirai牛逼" }</param>
    /// <returns></returns>
    internal static MessageBase GetMessageBase(string data)
    {
        try
        {
            var raw = JsonConvert.DeserializeObject<MessageBase>(data);

            if (raw!.Type == Messages.Quote)
            {
                var quote = JsonConvert.DeserializeObject<QuoteMessage>(data);

                quote!.Origin = data.FetchJToken("origin")!
                    .Select(x => GetMessageBase(x.ToString()))
                    .ToArray();
            
                return quote;
            }

            if (raw!.Type == Messages.Forward)
            {
                var forward = JsonConvert.DeserializeObject<ForwardMessage>(data);

                forward!.NodeList = data.FetchJToken("nodeList")!
                    .Select(x =>
                    {
                        var node = x.ToObject<ForwardMessage.ForwardNode>();
                        node!.MessageChain = x.Fetch("messageChain")!.DeserializeMessageChain();

                        return node;
                    })
                    .ToArray();

                return forward;
            }

            return JsonConvert.DeserializeObject(data,
                MessageBases.First(message => message.Type == raw!.Type)
                    .GetType()) as MessageBase;
        }
        catch
        {
            var re = JsonConvert.DeserializeObject<UnknownMessage>(data);
            re!.RawJson = data;
            return re;
        }
        
    }
    
    /// <summary>
    ///     根据json动态解析正确的消息接收器子类
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    internal static MessageReceiverBase GetMessageReceiverBase(string data)
    {
        try
        {
            var raw = JsonConvert.DeserializeObject<MessageReceiverBase>(data);

            var type = MessageReceiverBases.First(receiver => receiver.Type == raw!.Type)
                .GetType();

            return JsonConvert.DeserializeObject(data, type) as MessageReceiverBase;
        }
        catch
        {
            var re = JsonConvert.DeserializeObject<UnknownReceiver>(data);
            re!.RawJson = data;
            return re;
        }
    }

    /// <summary>
    ///     根据json动态解析对应的事件子类
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    internal static EventBase GetEventBase(string data)
    {
        try
        {
            var raw = JsonConvert.DeserializeObject<EventBase>(data);

            return JsonConvert.DeserializeObject(data,
                EventBases.First(message => message.Type == raw!.Type)
                    .GetType()) as EventBase;
        }
        catch
        {
            var re = JsonConvert.DeserializeObject<UnknownEvent>(data);
            re!.RawJson = data;
            return re;
        }
    }

    /// <summary>
    /// 反序列化消息链
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    internal static MessageChain DeserializeMessageChain(this string data)
    {
        return data.ToJArray()
            .Select(token => ReflectionUtils.GetMessageBase(token.ToString()))
            .ToMessageChain();
    }
}