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

        public async Task<IEnumerable<Friend>> GetFriendList()
        {
            var response = await _bot.Get("friendList");
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<Friend>());
        }
        
        public async Task<IEnumerable<Group>> GetGroupList()
        {
            var response = await _bot.Get("groupList");
            var result = response
                .ToJObject()
                .Fetch("data")
                .ToJArray();

            return result.Select(token => token.ToObject<Group>());
        }
    }
}