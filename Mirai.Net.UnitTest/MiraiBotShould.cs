using System;
using Mirai.Net.Sessions;
using Xunit;

namespace Mirai.Net.UnitTest
{
    public class MiraiBotShould
    {
        [Theory]
        [InlineData("http://localhost:8888")]
        [InlineData("https://localhost:8888")]
        [InlineData("http://localhost:8888/")]
        [InlineData("https://localhost:8888/")]
        [InlineData("localhost:8888/")]
        [InlineData("localhost:8888")]
        public void HasCorrectAddress(string url)
        {
            var bot = new MiraiBot
            {
                Address = url
            };

            Assert.True(bot.Address == "localhost:8888");
        }
    }
}