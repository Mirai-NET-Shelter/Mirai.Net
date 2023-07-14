using Manganese.Array;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using System.Linq;

namespace Mirai.Net.Sessions.Http.Managers
{

    /// <summary>
    /// 控制台管理器
    /// </summary>
    public static class ConsoleManager
    {
#nullable enable
        /// <summary>
        /// <para>登录指令</para>
        /// <para>登录后的账号会生成新的SessionKey 使用已有的MiraiBot实例是无法连接到该账号的</para>
        /// <para>如果配置相同（QQ Address VerifyKey）可以再次在同一个MiraiBot上使用LaunchAsync方法之后就可以正常使用了</para>
        /// <para>在LaunchAsync之前使用的任何Subscribe方法都不会应用于新登录的账号 必须重新Subscribe</para>
        /// </summary>
        /// <param name="qq"></param>
        /// <param name="password"></param>
        /// <param name="protocol"></param>
        /// <returns></returns>
        public static async Task LoginAsync(string qq, string password, Protocol? protocol = null)
        {
            var command = protocol is null
                ? new PlainMessage[]
                {
                    "/login",
                    qq,
                    password
                }
                : new PlainMessage[]
                {
                    "/login",
                    qq,
                    password,
                    protocol.ToString()
                };

            await HttpEndpoints.ExecuteCommand.PostJsonAsync(new
            {
                command
            });
        }
#nullable restore

        /// <summary>
        /// 关闭指令
        /// </summary>
        /// <returns></returns>
        public static async Task StopAsync()
        {
            var command = new PlainMessage[] { "/stop" };

            await HttpEndpoints.ExecuteCommand.PostJsonAsync(new
            {
                command
            });
        }

        /// <summary>
        /// 登出指令
        /// </summary>
        /// <param name="qq"></param>
        /// <returns></returns>
        public static async Task LogoutAsync(string qq)
        {
            var command = new PlainMessage[] { "/logout", qq };

            await HttpEndpoints.ExecuteCommand.PostJsonAsync(new
            {
                command
            });
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="commands">
        /// <para>命令与参数</para>
        /// </param>
        /// <returns></returns>
        public static async Task ExecuteCommandAsync(params string[] commands)
        {
            var builder = new System.Text.StringBuilder();

            foreach (var item in commands)
            {
                builder.Append(item);

                builder.Append(' ');
            }

            var command = new PlainMessage[] { builder.ToString().Trim() };

            await HttpEndpoints.ExecuteCommand.PostJsonAsync(new
            {
                command
            });
        }

        /// <summary>
        /// 使用消息执行命令
        /// </summary>
        /// <param name="command">
        /// <para>命令与参数 如果使用纯文本的话需要将整条命令写在同一个PlainMessage中</para>
        /// <para>控制台支持以不同消息类型作为指令的参数, 执行命令需要以消息类型作为参数, 若执行纯文本的命令, 构建多个文本格式的消息控制台会将第一个消息作为指令名, 后续消息作为参数</para>
        /// </param>
        /// <returns></returns>
        public static async Task ExecuteMessageCommandAsync(IEnumerable<MessageBase> command)
        {
            await HttpEndpoints.ExecuteCommand.PostJsonAsync(new
            {
                command
            });
        }

        /// <summary>
        /// <para>注册命令</para>
        /// <para>注册的命令会直接覆盖已有的指令(包括控制台内置的指令)</para>
        /// </summary>
        /// <param name="name">指令名</param>
        /// <param name="usage">使用说明</param>
        /// <param name="description">命令描述</param>
        /// <returns></returns>
        public static async Task RegisterCommandAsync(string name, string usage, string description)
        {
            await HttpEndpoints.RegisterCommand.PostJsonAsync(new
            {
                name,
                usage,
                description
            });
        }

        /// <summary>
        /// <para>注册命令</para>
        /// <para>注册的命令会直接覆盖已有的指令(包括控制台内置的指令)</para>
        /// </summary>
        /// <param name="command">命令</param>
        /// <returns></returns>
        public static async Task RegisterCommandAsync(Command command)
        {
            await HttpEndpoints.RegisterCommand.PostJsonAsync(command);
        }

        /// <summary>
        /// 注册用的命令
        /// </summary>
        public record Command
        {

            /// <summary>
            /// 指令名
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// 指令别名
            /// </summary>
            [JsonProperty("alias")]
            public IEnumerable<string> Alias { get; set; }

            /// <summary>
            /// 使用说明
            /// </summary>
            [JsonProperty("usage")]
            public string Usage { get; set; }

            /// <summary>
            /// 命令描述
            /// </summary>
            [JsonProperty("description")]
            public string Description { get; set; }
        }

        /// <summary>
        /// 命令被执行
        /// </summary>
        public record CommandExecutedEvent : EventBase
        {
            /// <summary>
            /// 事件类型
            /// </summary>
            public override Events Type { get; set; } = Events.CommandExecuted;

            /// <summary>
            /// 命令名称
            /// </summary>
            [JsonProperty("name")] public string Name { get; set; }
#nullable enable
            /// <summary>
            /// 发送命令的好友, 从控制台发送为 null
            /// </summary>
            [JsonProperty("friend")] public string? FriendId { get; set; }

            /// <summary>
            /// 发送命令的群成员, 从控制台发送为 null
            /// </summary>
            [JsonProperty("member")] public string? MemberId { get; set; }
#nullable restore
            /// <summary>
            /// 指令的参数, 以消息类型传递
            /// </summary>
            [JsonProperty("args")] public dynamic Args { get; set; }
        }

    }

    /// <summary>
    /// 可选的登录协议
    /// </summary>
    public enum Protocol
    {
        /// <summary>
        /// 安卓手机
        /// </summary>
        ANDROID_PHONE,

        /// <summary>
        /// 安卓平板
        /// </summary>
        ANDROID_PAD,

        /// <summary>
        /// 安卓手表
        /// </summary>
        ANDROID_WATCH
    }
}
