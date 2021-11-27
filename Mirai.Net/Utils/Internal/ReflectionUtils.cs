using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AHpx.Extensions.JsonExtensions;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Newtonsoft.Json;

namespace Mirai.Net.Utils.Internal;

public static class ReflectionUtils
{
    /// <summary>
    ///     获取某个命名空间下所有类的默认实例
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
        var root = JsonConvert.DeserializeObject<MessageBase>(data);

        if (root!.Type == Messages.Quote)
        {
            var quote = JsonConvert.DeserializeObject<QuoteMessage>(data);

            quote!.Origin = data.FetchJToken("origin")
                .Select(x => GetMessageBase(x.ToString()))
                .ToArray();
            
            return quote;
        }

        if (root!.Type == Messages.Forward)
        {
            var forward = JsonConvert.DeserializeObject<ForwardMessage>(data);

            forward!.NodeList = data.FetchJToken("nodeList")
                .Select(x =>
                {
                    var node = x.ToObject<ForwardMessage.ForwardNode>();
                    node!.MessageChain = x.FetchJToken("messageChain").Select(z => GetMessageBase(z.ToString()))
                        .ToArray();

                    return node;
                })
                .ToArray();

            return forward;
        }

        return JsonConvert.DeserializeObject(data,
            MessageBases.First(message => message.Type == root!.Type)
                .GetType()) as MessageBase;
    }
    
    /// <summary>
    ///     根据json动态解析正确的消息接收器子类
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    internal static MessageReceiverBase GetMessageReceiverBase(string data)
    {
        var root = JsonConvert.DeserializeObject<MessageReceiverBase>(data);

        return JsonConvert.DeserializeObject(data,
            MessageReceiverBases.First(receiver => receiver.Type == root!.Type)
                .GetType()) as MessageReceiverBase;
    }

    /// <summary>
    ///     根据json动态解析对应的事件子类
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    internal static EventBase GetEventBase(string data)
    {
        var root = JsonConvert.DeserializeObject<EventBase>(data);

        return JsonConvert.DeserializeObject(data,
            EventBases.First(message => message.Type == root!.Type)
                .GetType()) as EventBase;
    }
}