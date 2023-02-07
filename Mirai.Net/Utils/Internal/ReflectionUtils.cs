using Manganese.Text;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Concretes;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Utils.Scaffolds;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

    #region Type Cache

    /// <summary>
    /// 将指定的类型集合转换为字典,<br/>
    /// 不需要在每次获取类型时调用类型的GetType方法, 提升每次获取实例类型时的性能。
    /// </summary>
    /// <param name="enumerable">实例集合</param>
    /// <typeparam name="T">作为字典键的枚举类型</typeparam>
    /// <typeparam name="R">作为字典值：枚举值对应类型的Type</typeparam>
    /// <returns></returns>
    private static Dictionary<T, Type> InitTypeHashSet<T, R>(IEnumerable<R> enumerable)
        where T : Enum
        where R : class
    {
        var dict = new Dictionary<T, Type>();

        foreach (var item in enumerable)
        {
            T key;
            Type type;
            switch (item)
            {
                case MessageReceiverBase receiverBase:
                    key = (T) Enum.Parse(typeof(T), receiverBase.Type.ToString());
                    type = receiverBase.GetType();
                    break;
                case MessageBase messageBase:
                    key = (T) Enum.Parse(typeof(T), messageBase.Type.ToString());
                    type = messageBase.GetType();
                    break;
                case EventBase eventBase:
                    key = (T) Enum.Parse(typeof(T), eventBase.Type.ToString());
                    type = eventBase.GetType();
                    break;
                default:
                    throw new ArgumentException("该方法不支持此类型使用！", typeof(R).FullName);
            }

            if (!dict.ContainsKey(key))
            {
                dict.Add(key, type);
            }
        }

        return dict;
    }

    /// <summary>
    ///     默认消息接收器实例
    /// </summary>
    private static readonly IEnumerable<MessageReceiverBase> MessageReceiverBases =
        GetDefaultInstances<MessageReceiverBase>(
            "Mirai.Net.Data.Messages.Receivers");

    /// <summary>
    ///     默认消息接收器类型字典(K: 接收器的类别, V: 实例的Type)
    /// </summary>
    private static readonly Dictionary<MessageReceivers, Type> MessageReceiverTypeDict =
        InitTypeHashSet<MessageReceivers, MessageReceiverBase>(MessageReceiverBases);


    /// <summary>
    ///     默认消息实例
    /// </summary>
    private static readonly IEnumerable<MessageBase> MessageBases =
        GetDefaultInstances<MessageBase>("Mirai.Net.Data.Messages.Concretes");

    /// <summary>
    ///     默认消息实例类型字典(K: 消息的类别, V: 实例的Type)
    /// </summary>
    private static readonly Dictionary<Messages, Type> MessageBaseTypeDict =
        InitTypeHashSet<Messages, MessageBase>(MessageBases);


    /// <summary>
    ///     默认事件实例
    /// </summary>
    private static readonly IEnumerable<EventBase> EventBases =
        GetDefaultInstances<EventBase>("Mirai.Net.Data.Events.Concretes");

    /// <summary>
    ///     默认事件实例类型字典(K: 事件类别, V: 实例Type)
    /// </summary>
    private static readonly Dictionary<Events, Type> EventTypeDict = InitTypeHashSet<Events, EventBase>(EventBases);

    #endregion


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

            // 因为有异常捕获来处理转换失败的情况, 如果获取不到类型那一定得抛出异常, 所以此处直接用索引获取实例类型.
            return JsonConvert.DeserializeObject(data, MessageBaseTypeDict[raw!.Type]) as MessageBase;
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

            // 因为有异常捕获来处理转换失败的情况, 如果获取不到类型那一定得抛出异常, 所以此处直接用索引获取.
            var type = MessageReceiverTypeDict[raw!.Type];

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

            // 因为有异常捕获来处理转换失败的情况, 如果获取不到类型那一定得抛出异常, 所以此处直接用索引获取实例的类型.
            return JsonConvert.DeserializeObject(data, EventTypeDict[raw!.Type]) as EventBase;
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