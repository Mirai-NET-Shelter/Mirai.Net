using System;
using System.Net.WebSockets;
using System.Runtime.ExceptionServices;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Websocket.Client;

namespace Mirai.Net.Utils.Extensions
{
    internal static class WebsocketExtensions
    {
        /// <summary>
        ///     获取websocket推送的消息是什么类型的
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        [HandleProcessCorruptedStateExceptions]
        internal static WebsocketAdapterNotifications GetNotificationType(this ResponseMessage message)
        {
            if (message.MessageType != WebSocketMessageType.Text || message.Text.IsNullOrEmpty())
                return WebsocketAdapterNotifications.Unknown;

            try
            {
                var json = message.Text.Fetch("data").ToJObject();

                if (!json.ContainsKey("type"))
                    return WebsocketAdapterNotifications.Unknown;

                return json.Fetch("type").Contains("Message") 
                    ? WebsocketAdapterNotifications.Message
                    : WebsocketAdapterNotifications.Event;
            }
            catch(Exception e)
            {
                return WebsocketAdapterNotifications.Unknown;
            }
        }
    }
}