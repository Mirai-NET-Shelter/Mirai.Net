using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Managers;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Managers
{
    [Obsolete("此类所有的方法未经测试通过，不推荐使用")]
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

            var jObj = result.Content.ToJObject();

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

        public async Task Rename(string fileId, string newName)
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/groupFileRename", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
                id = fileId,
                rename = newName
            }.ToJson());

            var jObj = result.Content.ToJObject();

            if (jObj.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObj.GetPropertyValue("msg"));
            }
        }

        public async Task Move(string fileId, string newPath)
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/groupFileMove", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
                id = fileId,
                movePath = newPath
            }.ToJson());

            var jObj = result.Content.ToJObject();

            if (jObj.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObj.GetPropertyValue("msg"));
            }
        }

        public async Task Delete(string fileId)
        {
            var result = await HttpUtility.Post($"{Bot.Session.GetUrl()}/groupFileDelete", new
            {
                sessionKey = Bot.Session.SessionKey,
                target = GroupId,
                id = fileId,
            }.ToJson());

            var jObj = result.Content.ToJObject();

            if (jObj.GetPropertyValue("code") != "0")
            {
                throw new Exception(jObj.GetPropertyValue("msg"));
            }
        }
    }
}