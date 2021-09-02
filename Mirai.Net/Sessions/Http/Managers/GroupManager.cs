using System;
using System.Threading.Tasks;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;

namespace Mirai.Net.Sessions.Http.Managers
{
    public static class GroupManager
    {
        #region Mute

        /// <summary>
        ///     禁言某群员
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="time"></param>
        public static async Task MuteAsync(string target, string group, int time)
        {
            var payload = new
            {
                target = group,
                memberId = target,
                time
            };

            await HttpEndpoints.Mute.PostJsonAsync(payload);
        }

        /// <see cref="MuteAsync(string,string,int)" />
        public static async Task MuteAsync(string target, string group, TimeSpan time)
        {
            await MuteAsync(target, group, Convert.ToInt32(time.TotalSeconds));
        }

        #endregion

        #region UnMute

        /// <summary>
        ///     取消禁言
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        public static async Task UnMuteAsync(string target, string group)
        {
            var payload = new
            {
                target = group,
                memberId = target
            };

            await HttpEndpoints.Unmute.PostJsonAsync(payload);
        }

        #endregion

        #region Kick

        /// <summary>
        ///     踢出某群员
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="message"></param>
        public static async Task KickAsync(string target, string group, string message = "")
        {
            var payload = new
            {
                target = group,
                memberId = target,
                msg = message
            };

            await HttpEndpoints.Kick.PostJsonAsync(payload);
        }

        #endregion

        #region Leave

        /// <summary>
        ///     bot退出某群
        /// </summary>
        /// <param name="target"></param>
        public static async Task LeaveAsync(string target)
        {
            var payload = new
            {
                target
            };

            await HttpEndpoints.Leave.PostJsonAsync(payload);
        }

        #endregion

        #region MuteAll

        /// <summary>
        ///     全体禁言
        /// </summary>
        /// <param name="target"></param>
        /// <param name="mute">是否禁言</param>
        public static async Task MuteAllAsync(string target, bool mute = true)
        {
            var endpoint = mute ? HttpEndpoints.MuteAll : HttpEndpoints.UnmuteAll;
            var payload = new
            {
                target
            };

            await endpoint.PostJsonAsync(payload);
        }

        #endregion

        #region Essence

        /// <summary>
        ///     设置精华消息
        /// </summary>
        /// <param name="target">消息id</param>
        public static async Task SetEssenceMessageAsync(string target)
        {
            var payload = new
            {
                target
            };

            await HttpEndpoints.SetEssence.PostJsonAsync(payload);
        }

        #endregion

        #region GroupSetting

        /// <summary>
        ///     获取群设置
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static async Task<GroupSetting> GetGroupSettingAsync(string target)
        {
            var response = await HttpEndpoints.GroupConfig.GetAsync(new { target });

            return JsonConvert.DeserializeObject<GroupSetting>(response);
        }

        /// <summary>
        ///     修改群设置
        /// </summary>
        /// <param name="target"></param>
        /// <param name="setting"></param>
        public static async Task SetGroupSettingAsync(string target, GroupSetting setting)
        {
            var payload = new
            {
                target,
                config = setting
            };

            await HttpEndpoints.GroupConfig.PostJsonAsync(payload);
        }

        #endregion

        #region MemberInfo

        /// <summary>
        ///     获取群员
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static async Task<Member> GetMemberAsync(string target, string group)
        {
            var response = await HttpEndpoints.MemberInfo.GetAsync(new
            {
                target = "group",
                memberId = target
            });

            return JsonConvert.DeserializeObject<Member>(response);
        }

        /// <summary>
        ///     修改群员设置,需要相关的权限
        /// </summary>
        /// <param name="target"></param>
        /// <param name="group"></param>
        /// <param name="card">群名片, 需要管理员权限</param>
        /// <param name="title">群头衔, 需要群主权限</param>
        /// <returns></returns>
        public static async Task<Member> SetMemberInfoAsync(string target, string group, string card = null, string title = null)
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

            await HttpEndpoints.MemberInfo.PostJsonAsync(payload);

            return await GetMemberAsync(target, group);
        }

        #endregion
    }
}