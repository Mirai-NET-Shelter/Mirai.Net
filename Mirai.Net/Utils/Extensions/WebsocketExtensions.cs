using System.Net.WebSockets;
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
        internal static WebsocketAdapterNotifications GetNotificationType(this ResponseMessage message)
        {
            if (message.MessageType != WebSocketMessageType.Text || message.Text.IsNullOrEmpty())
                return WebsocketAdapterNotifications.Unknown;

            try
            {
                var json = message.Text.Fetch("data").ToJObject();

                if (json.Fetch("type").Contains("Message")) return WebsocketAdapterNotifications.Message;

                return WebsocketAdapterNotifications.Event;
            }
            catch
            {
                return WebsocketAdapterNotifications.Unknown;
            }
        }
    }
}