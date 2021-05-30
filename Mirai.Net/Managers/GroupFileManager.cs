using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Managers;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Managers
{
    public class GroupFileManager
    {
        public string GroupId { get; set; }

        public GroupFileManager(string groupId = null)
        {
            GroupId = groupId;
        }

        public async Task<IEnumerable<GroupFileInfo>> GetGroupFileList(string dir = null)
        {
            var url =
                $"{Bot.Session.GetUrl()}/groupFileList?sessionKey={Bot.Session.SessionKey}&target={GroupId}" +
                (string.IsNullOrEmpty(dir) ? null : $"&dir={dir}");

            var result = await HttpUtility.Get(url);
            
            return JArray.Parse(result.Content).ToObject<IEnumerable<GroupFileInfo>>();
        }

        public async Task CreateDirectory(string dirName)
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/groupMkdir", new
            {
                sessionKey = Bot.Session.SessionKey,
                group = GroupId,
                dir = dirName
            }.ToJson());

            var jObj = result.ToJObject();

            if (jObj.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObj.GetPropertyValue("msg"));
            }
        }

        public async Task<GroupFileInfoDetail> GetFileInfoDetail(string fileId)
        {
            var url =
                $"{Bot.Session.GetUrl()}/groupFileInfo?sessionKey={Bot.Session.SessionKey}&target={GroupId}&id={fileId}";

            var result = await HttpUtility.Get(url);

            return result.Content.ToObject<GroupFileInfoDetail>();
        }
    }
}