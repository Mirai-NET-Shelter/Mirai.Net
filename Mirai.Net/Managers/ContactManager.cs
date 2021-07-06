using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Mirai.Net.Data.Contact;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Managers
{
    public class ContactManager
    {
        private readonly MiraiBot _bot;

        public ContactManager(MiraiBot bot)
        {
            _bot = bot;
        }

        /// <summary>
        /// 获取bot账号的好友列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Friend>> GetFriendList()
        {
            var response = await _bot.Get("friendList");
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<Friend>());
        }
        
        /// <summary>
        /// 获取bot账号的QQ群列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Group>> GetGroupList()
        {
            var response = await _bot.Get("groupList");
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<Group>());
        }
        
        /// <summary>
        /// 获取某个QQ群的成员列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GroupMember>> GetGroupMemberList(string id)
        {
            var response = await _bot.Get("memberList", new[]
            {
                ("target", id)
            });
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<GroupMember>());
        }

        public async Task<Profile> GetBotProfile()
        {
            var response = await _bot.Get("botProfile");
            var result = response
                .ToJObject();

            return result.ToObject<Profile>();
        }

        public async Task<Profile> GetFriendProfile(string id)
        {
            var response = await _bot.Get("friendProfile", new[]
            {
                ("target", id)
            });
            var result = response
                .ToJObject();

            return result.ToObject<Profile>();
        }
    }
}