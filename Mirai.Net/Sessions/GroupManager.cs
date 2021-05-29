using System;
using System.Threading.Tasks;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net.Sessions
{
    public class GroupManager
    {
        public string GroupId { get; set; }

        public GroupManager(string groupId = null)
        {
            GroupId = groupId;
        }

        public async Task Mute(string target, int seconds = 600)
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/mute", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
                memberId = target,
                time = seconds
            }.ToJson());

            var jObject = result.Content.ToJObject();

            if (jObject.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObject.GetPropertyValue("msg"));
            }
        }

        public async Task UnMute(string target)
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/unmute", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
                memberId = target,
            }.ToJson());

            var jObject = result.Content.ToJObject();

            if (jObject.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObject.GetPropertyValue("msg"));
            }
        }

        public async Task Kick(string target, string message = "")
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/kick", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
                memberId = target,
                msg = message
            }.ToJson());

            var jObject = result.Content.ToJObject();

            if (jObject.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObject.GetPropertyValue("msg"));
            }
        }

        public async Task Leave()
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/quit", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
            }.ToJson());

            var jObject = result.Content.ToJObject();

            if (jObject.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObject.GetPropertyValue("msg"));
            }
        }

        public async Task MuteAll()
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/muteAll", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
            }.ToJson());

            var jObject = result.Content.ToJObject();

            if (jObject.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObject.GetPropertyValue("msg"));
            }
        }
        
        public async Task UnMuteAll()
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/unmuteAll", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
            }.ToJson());

            var jObject = result.Content.ToJObject();

            if (jObject.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObject.GetPropertyValue("msg"));
            }
        }
    }
}