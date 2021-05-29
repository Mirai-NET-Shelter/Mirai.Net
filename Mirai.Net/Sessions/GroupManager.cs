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

        public async Task<bool> Mute(string target, int seconds = 600)
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
            
            return jObject.GetPropertyValue("code") == "0";
        }
        
        public async Task<bool> UnMute(string target)
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
            
            return jObject.GetPropertyValue("code") == "0";
        }
        
        public async Task<bool> Kick(string target, string message = "")
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
            
            return jObject.GetPropertyValue("code") == "0";
        }
        
        public async Task<bool> Leave()
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
            
            return jObject.GetPropertyValue("code") == "0";
        }
    }
}