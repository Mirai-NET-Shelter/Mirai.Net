using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Xunit;

namespace Mirai.Net.UnitTest
{
    public class AccountManagerShould
    {
        private readonly MiraiBot _bot;
        private readonly AccountManager _manager;

        public AccountManagerShould()
        {
            _bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 2672886221,
                VerifyKey = "1145141919810"
            };

            _manager = new AccountManager(_bot);
        }

        [Fact]
        public async Task HasCorrectFriendList()
        {
            await _bot.Launch();
            var list = await _manager.GetFriends();

            Assert.True(list.Count() > 5);
        }

        [Fact]
        public async Task HasCorrectGroupList()
        {
            await _bot.Launch();
            var list = await _manager.GetGroups();

            Assert.True(list.Count() > 3);
        }

        [Fact]
        public async Task HasCorrectMemberList()
        {
            await _bot.Launch();
            var list = await _manager.GetGroupMembers(110838222);

            Assert.True(list.Count() > 50);
        }

        [Fact]
        public async Task HasCorrectProfile()
        {
            await _bot.Launch();
            var item = await _manager.GetBotProfile();

            Assert.True(item.Age.IsInteger());
            Assert.True(item.Level.IsInteger());
        }

        [Fact]
        public async Task HasCorrectFriendProfile()
        {
            await _bot.Launch();
            var item = await _manager.GetFriendProfile(2933170747);

            Assert.True(item.Age.IsInteger());
            Assert.True(item.Level.IsInteger());
        }

        [Fact]
        public async Task HasCorrectMemberProfile()
        {
            await _bot.Launch();
            var item = await _manager.GetMemberProfile(2933170747, 110838222);

            Assert.True(item.Age.IsInteger());
            Assert.True(item.Level.IsInteger());
        }
    }
}