using System.ComponentModel;

namespace Mirai.Net.Data.Sessions
{
    /// <summary>
    ///     MiraiBot类内部需要的Websocket请求端点
    /// </summary>
    internal enum WebsocketEndpoints
    {
        [Description("message")] Message,
        [Description("all")] All,
        [Description("event")] Event
    }
}