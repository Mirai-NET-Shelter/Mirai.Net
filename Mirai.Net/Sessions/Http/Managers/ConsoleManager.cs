using Manganese.Array;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;

namespace Mirai.Net.Sessions.Http.Managers
{

    /// <summary>
    /// 控制台管理器
    /// </summary>
    /// 在功能稳定前保持可见性为 internal
    [Experimental]
#if DEBUG
    public static class ConsoleManager
#else
    internal static class ConsoleManager
#endif
    {

        /// <summary>
        /// 内部小把戏
        /// </summary>
        /// 在功能稳定前使用此方法加入内部事件类型
        static ConsoleManager()
        {
            var field = typeof(ReflectionUtils).GetField("EventBases", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            if (field != null)
            {
                if (field.GetValue(null) == null)
                {
                    field.SetValue(null, ReflectionUtils.GetDefaultInstances<EventBase>("Mirai.Net.Data.Events.Concretes"));
                }
                var eventBases = field.GetValue(null);
                ((IEnumerable<EventBase>)eventBases).Add(new EventBase[] { new CommandExecutedEvent() });
            }
        }

        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="command">
        /// <para>命令与参数</para>
        /// <para>控制台支持以不同消息类型作为指令的参数, 执行命令需要以消息类型作为参数, 若执行纯文本的命令, 构建多个文本格式的消息控制台会将第一个消息作为指令名, 后续消息作为参数</para>
        /// </param>
        /// <returns></returns>
        public static async Task ExecuteCommandAsync(object[] command)
        {
            await HttpEndpoints.ExecuteCommand.PostJsonAsync(command);
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
        /// 命令
        /// </summary>
        /// 在功能稳定前保持此类为内部类
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
            public string[] Alias { get; set; }

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
        /// 在功能稳定前保持此类为内部类
        public record CommandExecutedEvent : EventBase
        {
            /// <summary>
            /// 事件类型
            /// </summary>
            public override Events Type { get; set; } = Events.CommandExecuted;

            /// <summary>
            /// 命令名称
            /// </summary>
            [JsonProperty("name")] public string Name { get; private set; }

            /// <summary>
            /// 发送命令的好友, 从控制台发送为 null
            /// </summary>
            [JsonProperty("friend")] public string FriendId { get; private set; }

            /// <summary>
            /// 发送命令的群成员, 从控制台发送为 nul
            /// </summary>
            [JsonProperty("member")] public string MemberId { get; private set; }

            /// <summary>
            /// 指令的参数, 以消息类型传递
            /// </summary>
            [JsonProperty("args")] public dynamic Args { get; private set; }
        }

    }
}
