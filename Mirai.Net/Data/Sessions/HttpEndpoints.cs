using System.ComponentModel;

namespace Mirai.Net.Data.Sessions
{
    /// <summary>
    ///     http请求端点
    /// </summary>
    internal enum HttpEndpoints
    {
        [Description("verify")] Verify,
        [Description("bind")] Bind,
        [Description("release")] Release,
        [Description("about")] About
    }
}