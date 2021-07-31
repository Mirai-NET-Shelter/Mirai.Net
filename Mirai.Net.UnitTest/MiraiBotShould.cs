using System;
using Mirai.Net.Sessions;
using Xunit;

namespace Mirai.Net.UnitTest
{
    public class MiraiBotShould
    {
        [Theory]
        [InlineData("http://localhost:8a888")]
        [InlineData("https://localhost:8888")]
        [InlineData("http://localhost:8888/")]
        [InlineData("https://localhost:8888/")]
        [InlineData("localhost:8888/")]
        [InlineData("localhost:8888'")]
        public void HasCorrectAddress(string url)
        {
            var ex = Assert.Throws<Exception>(() =>
            {
                var bot = new MiraiBot
                {
                    Address = url
                };
            });

            Assert.Contains("错误的地址", ex.Message);
        }
    }
}