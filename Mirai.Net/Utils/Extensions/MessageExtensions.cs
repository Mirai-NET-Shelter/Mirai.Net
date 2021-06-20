using Websocket.Client;

namespace Mirai.Net.Utils.Extensions
{
    /// <summary>
    /// 消息相关拓展封装
    /// </summary>
    public static class MessageExtensions
    {
        /// <summary>
        /// 判断websocket收到的消息是不是事件消息
        /// </summary>
        /// <returns></returns>
        public static bool IsEvent(this ResponseMessage message)
        {
            var json = message.Text.ToJObject();

            if (json.Fetch("data").ToJObject().ContainsKey("session"))
            {
                return false;
            }
            
            var type = json["data"].Fetch("type");

            return type.ToLower().Contains("event");
        }
    }
}