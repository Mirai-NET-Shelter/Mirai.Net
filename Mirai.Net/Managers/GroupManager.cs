using System;
using System.Threading.Tasks;
using Mirai.Net.Data.Contact;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Managers
{
    public class GroupManager
    {
        private readonly MiraiBot _bot;

        public GroupManager(MiraiBot bot, string group = null)
        {
            _bot = bot;
            Group = group;
        }

        /// <summary>
        /// 要操作的群
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// 禁言某群员
        /// </summary>
        /// <param name="target">群员qq</param>
        /// <param name="time">单位是秒，最长30天</param>
        public async Task Mute(string target, int time)
        {
            var payload = new
            {
                target = Group,
                memberId = target,
                time
            }.ToJsonString();

            await _bot.PostJson("mute", payload);
        }
        
        /// <summary>
        /// 禁言某群员
        /// </summary>
        /// <param name="target">群员qq</param>
        /// <param name="time">最长30天</param>
        public async Task Mute(string target, TimeSpan time)
        {
            // 我们并不关心精度损失
            await Mute(target, Convert.ToInt32(time.TotalSeconds));
        }

        /// <summary>
        /// 解除禁言
        /// </summary>
        /// <param name="target">群员qq</param>
        public async Task UnMute(string target)
        {
            var payload = new
            {
                target = Group,
                memberId = target,
            }.ToJsonString();

            await _bot.PostJson("unmute", payload);
        }

        /// <summary>
        /// 踢出某群员
        /// </summary>
        /// <param name="target">群员qq</param>
        /// <param name="message">消息</param>
        public async Task Kick(string target, string message = "")
        {
            var payload = new
            {
                target = Group,
                memberId = target,
                msg = message
            }.ToJsonString();

            await _bot.PostJson("kick", payload);
        }

        /// <summary>
        /// 退出操作的群
        /// </summary>
        public async Task Leave()
        {
            var payload = new
            {
                target = Group,
            }.ToJsonString();

            await _bot.PostJson("quit", payload);
        }

        /// <summary>
        /// 全员禁言
        /// </summary>
        public async Task MuteAll()
        {
            var payload = new
            {
                target = Group,
            }.ToJsonString();

            await _bot.PostJson("muteAll", payload);
        }

        /// <summary>
        /// 解除全员禁言
        /// </summary>
        public async Task UnMuteAll()
        {
            var payload = new
            {
                target = Group,
            }.ToJsonString();

            await _bot.PostJson("unmuteAll", payload);
        }

        /// <summary>
        /// 设置精华消息
        /// </summary>
        /// <param name="messageId">消息id</param>
        public async Task SetBible(string messageId)
        {
            var payload = new
            {
                target = messageId,
            }.ToJsonString();

            await _bot.PostJson("setEssence", payload);
        }

        /// <summary>
        /// 获取群设置
        /// </summary>
        /// <returns></returns>
        public async Task<GroupConfig> GetGroupConfig()
        {
            var response = await _bot.Get("groupConfig", new[]
            {
                ("target", Group)
            });

            return response.ToEntity<GroupConfig>();
        }
        
        /// <summary>
        /// 设置群
        /// </summary>
        public async Task SetGroupConfig(GroupConfig config)
        {
            var payload = new
            {
                target = Group,
                config
            }.ToJsonString();

            await _bot.PostJson("groupConfig", payload);
        }

        /// <summary>
        /// 获取群员资料，不同于Profile，这个方法获取的是群员在群里的资料
        /// </summary>
        /// <returns></returns>
        public async Task<GroupMember> GetGroupMemberInfo(string target)
        {
            var response = await _bot.Get("memberInfo", new[]
            {
                ("target", Group),
                ("memberId", target)
            });

            return response.ToEntity<GroupMember>();
        }

        /// <summary>
        /// 设置群员的群名片和头衔，需要bot有对应的权限
        /// </summary>
        /// <param name="member">通常应该是获取到GroupMember对象之后再修改值然后再传进来</param>
        public async Task SetGroupMemberInfo(GroupMember member)
        {
            var payload = new
            {
                target = Group,
                memberId = member.Id,
                info = new
                {
                    name = member.Name,
                    specialTitle = member.SpecialTitle
                }
            }.ToJsonString();

            await _bot.PostJson("memberInfo", payload);
        }

        /// <summary>
        /// 设置群员的群名片
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name">要设置的群名片</param>
        public async Task SetGroupMemberName(string target, string name)
        {
            var payload = new
            {
                target = Group,
                memberId = target,
                info = new
                {
                    name,
                }
            }.ToJsonString();

            await _bot.PostJson("memberInfo", payload);
        }

        /// <summary>
        /// 设置群员的头衔
        /// </summary>
        /// <param name="target"></param>
        /// <param name="title">头衔</param>
        public async Task SetGroupMemberTitle(string target, string title)
        {
            var payload = new
            {
                target = Group,
                memberId = target,
                info = new
                {
                    specialTitle = title,
                }
            }.ToJsonString();

            await _bot.PostJson("memberInfo", payload);
        }
    }
}