using System;
using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Managers;
using Newtonsoft.Json;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class GroupManager
    {
        public readonly MiraiBot Bot = MiraiBotFactory.Bot;

        #region Mute

        /// <summary>
        ///     禁言某群员
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="time"></param>
        public async Task Mute(string target, string group, int time)
        {
            var payload = new
            {
                target = group,
                memberId = target,
                time
            };

            await this.SendOperate(HttpEndpoints.Mute, payload);
        }

        /// <see cref="Mute(string,string,int)" />
        public async Task Mute(string target, string group, TimeSpan time)
        {
            await Mute(target, group, Convert.ToInt32(time.TotalSeconds));
        }

        /// <see cref="Mute(string,string,int)" />
        public async Task Mute(long target, long group, TimeSpan time)
        {
            await Mute(target.ToString(), group.ToString(), Convert.ToInt32(time.TotalSeconds));
        }

        /// <see cref="Mute(string,string,int)" />
        public async Task Mute(long target, long group, int time)
        {
            await Mute(target.ToString(), group.ToString(), time);
        }

        #endregion

        #region UnMute

        /// <summary>
        ///     取消禁言
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        public async Task UnMute(string target, string group)
        {
            var payload = new
            {
                target = group,
                memberId = target
            };

            await this.SendOperate(HttpEndpoints.Unmute, payload);
        }

        /// <see cref="UnMute(string,string)" />
        public async Task UnMute(long target, long group)
        {
            await UnMute(target.ToString(), group.ToString());
        }

        #endregion

        #region Kick

        /// <summary>
        ///     踢出某群员
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="message"></param>
        public async Task Kick(string target, string group, string message = "")
        {
            var payload = new
            {
                target = group,
                memberId = target,
                msg = message
            };

            await this.SendOperate(HttpEndpoints.Kick, payload);
        }

        /// <see cref="Kick(string,string,string)" />
        public async Task Kick(long target, long group, string message = "")
        {
            await Kick(target.ToString(), group.ToString(), message);
        }

        #endregion

        #region Leave

        /// <summary>
        ///     bot退出某群
        /// </summary>
        /// <param name="target"></param>
        public async Task Leave(string target)
        {
            var payload = new
            {
                target
            };

            await this.SendOperate(HttpEndpoints.Leave, payload);
        }

        /// <see cref="Leave(string)" />
        public async Task Leave(long target)
        {
            await Leave(target.ToString());
        }

        #endregion

        #region MuteAll

        /// <summary>
        ///     全体禁言
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mute">是否禁言</param>
        public async Task MuteAll(string target, bool mute = true)
        {
            var endpoint = mute ? HttpEndpoints.MuteAll : HttpEndpoints.UnmuteAll;
            var payload = new
            {
                target
            };

            await this.SendOperate(endpoint, payload);
        }

        /// <see cref="MuteAll(string,bool)" />
        public async Task MuteAll(long target, bool mute = true)
        {
            await MuteAll(target.ToString(), mute);
        }

        #endregion

        #region Essence

        /// <summary>
        ///     设置精华消息
        /// </summary>
        /// <param name="target">消息id</param>
        public async Task SetEssenceMessage(string target)
        {
            var payload = new
            {
                target
            };

            await this.SendOperate(HttpEndpoints.SetEssence, payload);
        }

        public async Task SetEssenceMessage(long target)
        {
            await SetEssenceMessage(target.ToString());
        }

        #endregion

        #region GroupSetting

        /// <summary>
        ///     获取群设置
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public async Task<GroupSetting> GetGroupSetting(string target)
        {
            var response = await Bot.GetHttp(HttpEndpoints.GroupConfig, true, ("target", target));

            return JsonConvert.DeserializeObject<GroupSetting>(response);
        }

        /// <see cref="GetGroupSetting(string)" />
        public async Task<GroupSetting> GetGroupSetting(long target)
        {
            return await GetGroupSetting(target.ToString());
        }

        /// <summary>
        ///     修改群设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="setting"></param>
        public async Task SetGroupSetting(string target, GroupSetting setting)
        {
            var payload = new
            {
                target,
                config = setting
            };

            await this.SendOperate(HttpEndpoints.GroupConfig, payload);
        }

        /// <see cref="SetGroupSetting(string,Mirai.Net.Data.Shared.GroupSetting)" />
        /// )"/>
        public async Task SetGroupSetting(long target, GroupSetting setting)
        {
            await SetGroupSetting(target.ToString(), setting);
        }

        #endregion

        #region MemberInfo

        /// <summary>
        ///     获取群员
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task<Member> GetMember(string target, string group)
        {
            var response = await Bot.GetHttp(HttpEndpoints.MemberInfo, true, ("target", group), ("memberId", target));

            Bot.EnsureSuccess(response);

            return JsonConvert.DeserializeObject<Member>(response);
        }

        /// <see cref="GetMember(string,string)" />
        public async Task<Member> GetMember(long target, long group)
        {
            return await GetMember(target.ToString(), group.ToString());
        }

        /// <summary>
        ///     修改群员设置,需要相关的权限
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="card">群名片, 需要管理员权限</param>
        /// <param name="title">群头衔, 需要群主权限</param>
        /// <returns></returns>
        public async Task<Member> SetMemberInfo(string target, string group, string card = null, string title = null)
        {
            var payload = new
            {
                target = group,
                memberId = target,
                info = new
                {
                    name = card,
                    specialTitle = title
                }
            };

            await this.SendOperate(HttpEndpoints.MemberInfo, payload);

            return await GetMember(target, group);
        }

        /// <see cref="SetMemberInfo(string,string,string,string)" />
        public async Task<Member> SetMemberInfo(long target, long group, string card = null, string title = null)
        {
            return await SetMemberInfo(target.ToString(), group.ToString(), card, title);
        }

        #endregion
    }
}