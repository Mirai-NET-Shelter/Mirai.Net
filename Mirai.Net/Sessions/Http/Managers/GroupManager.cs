using System;
using System.Linq;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
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

        /// <summary>
        ///     禁言某群员
        /// </summary>
        /// <param name="member"></param>
        /// <param name="time"></param>
        public static async Task MuteAsync(this Member member, int time)
        {
            await GroupManager.MuteAsync(member.Id, member.Group.Id, time);
        }

        /// <see cref="MuteAsync(Member,int)" />
        public static async Task MuteAsync(this Member member, TimeSpan time)
        {
            await GroupManager.MuteAsync(member.Id, member.Group.Id, time);
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
        
        /// <summary>
        ///     取消禁言
        /// </summary>
        /// <param name="member"></param>
        public static async Task UnMuteAsync(this Member member)
        {
            await GroupManager.UnMuteAsync(member.Id, member.Group.Id);
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

        /// <summary>
        ///     踢出某群员
        /// </summary>
        /// <param name="member"></param>
        /// <param name="message"></param>
        public static async Task KickAsync(this Member member, string message = "")
        {
            await KickAsync(member.Id, member.Group.Id);
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

        /// <summary>
        /// bot退出某群
        /// </summary>
        /// <param name="group"></param>
        public static async Task LeaveAsync(this Group group)
        {
            await LeaveAsync(group.Id);
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

        /// <summary>
        ///     全体禁言
        /// </summary>
        /// <param name="group"></param>
        /// <param name="mute">是否禁言</param>
        public static async Task MuteAllAsync(this Group group, bool mute = true)
        {
            await MuteAllAsync(group.Id, mute);
        }


        #endregion

        #region Essence

        /// <summary>
        ///     设置精华消息
        /// </summary>
        /// <param name="messageId">消息id</param>
        public static async Task SetEssenceMessageAsync(string messageId)
        {
            var payload = new
            {
                target = messageId
            };

            await HttpEndpoints.SetEssence.PostJsonAsync(payload);
        }

        /// <summary>
        ///     设置精华消息
        /// </summary>
        /// <param name="receiver"></param>
        public static async Task SetEssenceMessageAsync(this MessageReceiverBase receiver)
        {
            var payload = new
            {
                target = receiver.MessageChain.OfType<SourceMessage>().First().MessageId
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
        /// 获取群设置
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public static async Task<GroupSetting> GetGroupSettingAsync(this Group group)
        {
            return await GetGroupSettingAsync(group.Id);
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

        /// <summary>
        ///     修改群设置
        /// </summary>
        /// <param name="group"></param>
        /// <param name="setting"></param>
        public static async Task SetGroupSettingAsync(this Group group, GroupSetting setting)
        {
            await SetGroupSettingAsync(group.Id, setting);
        }

        #endregion

        #region MemberInfo

        /// <summary>
        ///     获取群员
        /// </summary>
        /// <param name="memberQQ"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public static async Task<Member> GetMemberAsync(string memberQQ, string group)
        {
            var response = await HttpEndpoints.MemberInfo.GetAsync(new
            {
                target = group,
                memberId = memberQQ
            });

            return JsonConvert.DeserializeObject<Member>(response);
        }

        /// <summary>
        ///     修改群员设置,需要相关的权限
        /// </summary>
        /// <param name="memberQQ"></param>
        /// <param name="group"></param>
        /// <param name="card">群名片, 需要管理员权限</param>
        /// <param name="title">群头衔, 需要群主权限</param>
        /// <returns></returns>
        public static async Task<Member> SetMemberInfoAsync(string memberQQ, string group, string card = null, string title = null)
        {
            var payload = new
            {
                target = group,
                memberId = memberQQ,
                info = new
                {
                    name = card,
                    specialTitle = title
                }
            };

            await HttpEndpoints.MemberInfo.PostJsonAsync(payload);

            return await GetMemberAsync(memberQQ, group);
        }

        #endregion
    }
}