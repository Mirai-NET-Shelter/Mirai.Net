using Manganese.Text;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mirai.Net.Sessions.Http.Managers;

/// <summary>
/// 群管理器
/// </summary>
public static class GroupManager
{
    #region Mute

    /// <summary>
    ///     禁言某群员
    /// </summary>
    /// <param name="memberId">禁言对象的QQ号</param>
    /// <param name="group">禁言对象所在的群号</param>
    /// <param name="time">禁言的时长</param>
    public static async Task MuteAsync(string memberId, string group, int time)
    {
        var payload = new
        {
            target = group,
            memberId = memberId,
            time
        };

        await HttpEndpoints.Mute.PostJsonAsync(payload);
    }

    /// <see cref="MuteAsync(string,string,int)" />
    public static async Task MuteAsync(string memberId, string group, TimeSpan time)
    {
        await MuteAsync(memberId, group, Convert.ToInt32(time.TotalSeconds));
    }

    /// <summary>
    ///     禁言某群员
    /// </summary>
    /// <param name="member">禁言的对象</param>
    /// <param name="time">禁言的时长</param>
    public static async Task MuteAsync(this Member member, int time)
    {
        await MuteAsync(member.Id, member.Group.Id, time);
    }

    /// <see cref="MuteAsync(Member,int)" />
    public static async Task MuteAsync(this Member member, TimeSpan time)
    {
        await MuteAsync(member.Id, member.Group.Id, time);
    }

    #endregion

    #region UnMute

    /// <summary>
    ///     取消禁言
    /// </summary>
    /// <param name="memberId">取消禁言对象的QQ号</param>
    /// <param name="group">取消禁言对象所在的群号</param>
    public static async Task UnMuteAsync(string memberId, string group)
    {
        var payload = new
        {
            target = group,
            memberId
        };

        await HttpEndpoints.Unmute.PostJsonAsync(payload);
    }

    /// <summary>
    ///     取消禁言
    /// </summary>
    /// <param name="member">取消禁言的对象</param>
    public static async Task UnMuteAsync(this Member member)
    {
        await UnMuteAsync(member.Id, member.Group.Id);
    }

    #endregion

    #region Kick

    /// <summary>
    ///     踢出某群员
    /// </summary>
    /// <param name="memberId">踢出对象的QQ号</param>
    /// <param name="group">踢出对象所在的群号</param>
    /// <param name="message">踢出的原因</param>
    public static async Task KickAsync(string memberId, string group, string message = "")
    {
        var payload = new
        {
            target = group,
            memberId = memberId,
            msg = message
        };

        await HttpEndpoints.Kick.PostJsonAsync(payload);
    }

    /// <summary>
    ///     踢出某群员
    /// </summary>
    /// <param name="member">踢出的对象</param>
    /// <param name="message">踢出的原因</param>
    public static async Task KickAsync(this Member member, string message = "")
    {
        await KickAsync(member.Id, member.Group.Id);
    }

    #endregion

    #region Leave

    /// <summary>
    ///     bot退出某群
    /// </summary>
    /// <param name="groupId">要退出的群号</param>
    public static async Task LeaveAsync(string groupId)
    {
        var payload = new
        {
            groupId
        };

        await HttpEndpoints.Leave.PostJsonAsync(payload);
    }

    /// <summary>
    ///     bot退出某群
    /// </summary>
    /// <param name="group">要退出的群</param>
    public static async Task LeaveAsync(this Group group)
    {
        await LeaveAsync(group.Id);
    }

    #endregion

    #region MuteAll

    /// <summary>
    ///     全体禁言
    /// </summary>
    /// <param name="groupId">目标群号</param>
    /// <param name="mute">是否禁言。 false为解除禁言，true为禁言</param>
    public static async Task MuteAllAsync(string groupId, bool mute = true)
    {
        var endpoint = mute ? HttpEndpoints.MuteAll : HttpEndpoints.UnmuteAll;
        var payload = new
        {
            groupId
        };

        await endpoint.PostJsonAsync(payload);
    }

    /// <summary>
    ///     全体禁言
    /// </summary>
    /// <param name="group">目标群</param>
    /// <param name="mute">是否禁言。 false为解除禁言，true为禁言</param>
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
    /// <param name="groupId">目标群号</param>
    public static async Task SetEssenceMessageAsync(string messageId, string groupId)
    {
        var payload = new
        {
            target = groupId,
            messageId
        };

        await HttpEndpoints.SetEssence.PostJsonAsync(payload);
    }

    /// <summary>
    ///     设置精华消息
    /// </summary>
    /// <param name="receiver"></param>
    public static async Task SetEssenceMessageAsync(this MessageReceiverBase receiver)
    {
        if (receiver is GroupMessageReceiver groupMessageReceiver)
        {
            await SetEssenceMessageAsync(receiver.MessageChain.OfType<SourceMessage>().Single().MessageId,
                groupMessageReceiver.GroupId);
        }
    }

    #endregion

    #region GroupSetting

    /// <summary>
    ///     获取群设置
    /// </summary>
    /// <param name="groupId">目标群号</param>
    /// <returns></returns>
    public static async Task<GroupSetting> GetGroupSettingAsync(string groupId)
    {
        var response = await HttpEndpoints.GroupConfig.GetAsync(new { target = groupId });

        return JsonConvert.DeserializeObject<GroupSetting>(response);
    }

    /// <summary>
    ///     获取群设置
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
    /// <param name="groupId">目标群号</param>
    /// <param name="setting">群设置</param>
    public static async Task SetGroupSettingAsync(string groupId, GroupSetting setting)
    {
        var payload = new
        {
            target = groupId,
            config = setting
        };

        await HttpEndpoints.GroupConfig.PostJsonAsync(payload);
    }

    /// <summary>
    ///     修改群设置
    /// </summary>
    /// <param name="group">目标群</param>
    /// <param name="setting">群设置</param>
    public static async Task SetGroupSettingAsync(this Group group, GroupSetting setting)
    {
        await SetGroupSettingAsync(group.Id, setting);
    }

    #endregion

    #region MemberInfo

    /// <summary>
    ///     获取群员
    /// </summary>
    /// <param name="memberQQ">目标的QQ号</param>
    /// <param name="group">目标群号</param>
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
    /// <param name="memberQQ">目标的QQ号</param>
    /// <param name="group">目标群号</param>
    /// <param name="card">群名片, 需要管理员权限</param>
    /// <param name="title">群头衔, 需要群主权限</param>
    /// <returns></returns>
    public static async Task<Member> SetMemberInfoAsync(string memberQQ, string group, string card = null,
        string title = null)
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

    #region Anno

    /// <summary>
    /// 获取指定群公告列表
    /// </summary>
    /// <param name="group">目标群号</param>
    /// <param name="offset">分页参数</param>
    /// <param name="size">分页参数，默认10</param>
    /// <returns></returns>
    public static async Task<IEnumerable<Announcement>> GetGroupAnnouncementAsync(string group, long offset = 0, long size = 10)
    {
        var response = await HttpEndpoints.GetAnnouncement.GetAsync(new
        {
            id = group,
            offset,
            size
        });

        return JsonConvert.DeserializeObject<IEnumerable<Announcement>>(response.Fetch("data"));
    }

    /// <summary>
    /// 向指定群发布群公告
    /// </summary>
    /// <param name="group">目标群号</param>
    /// <param name="content">公告内容</param>
    /// <param name="pinned">是否置顶</param>
    /// <returns></returns>
    public static async Task<Announcement> PublishGroupAnnouncementAsync(string group, string content, bool pinned = true)
    {
        var setting = new AnnouncementSetting
        {
            Target = group,
            Content = content,
            Pinned = pinned
        };

        return await PublishGroupAnnouncementAsync(setting);
    }

    /// <summary>
    /// 向指定群发布群公告
    /// </summary>
    /// <param name="announcementSetting">群公告设置</param>
    /// <returns></returns>
    public static async Task<Announcement> PublishGroupAnnouncementAsync(AnnouncementSetting announcementSetting)
    {
        var response = await HttpEndpoints.PubAnnouncement.PostJsonAsync(announcementSetting);

        return JsonConvert.DeserializeObject<Announcement>(response.Fetch("data"));
    }

    /// <summary>
    /// 删除指定群中一条公告
    /// </summary>
    /// <param name="group">目标群号</param>
    /// <param name="fid">群公告唯一id</param>
    /// <returns></returns>
    public static async Task DeleteGroupAnnouncementAsync(string group, string fid)
    {
        await HttpEndpoints.DelAnnouncement.PostJsonAsync(new
        {
            id = group,
            fid
        });
    }

    #endregion

}