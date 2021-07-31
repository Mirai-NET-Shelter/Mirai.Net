using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Data.Sessions;
using Mirai.Net.Data.Shared;
using Mirai.Net.Utils;

namespace Mirai.Net.Sessions.Http.Concretes
{
    public class AccountManager
    {
        private readonly MiraiBot _bot;

        public AccountManager(MiraiBot bot)
        {
            _bot = bot;
        }
        
        /// <summary>
        /// 获取bot账号的好友列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Friend>> GetFriends()
        {
            var raw = await _bot.GetHttp(HttpEndpoints.FriendList);
            var json = raw.ToJArray();

            return json.Select(x => x.ToObject<Friend>());
        }
        
        
    }
}