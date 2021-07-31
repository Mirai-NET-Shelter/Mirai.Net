using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Mirai.Net.Sessions;
using Mirai.Net.Utils;
using Xunit;

namespace Mirai.Net.UnitTest
{
    public class MiraiHttpUtilitiesShould
    {
        private MiraiBot _bot;

        public MiraiHttpUtilitiesShould()
        {
            _bot = new MiraiBot
            {
                Address = "localhost:8080",
                QQ = 2672886221,
                VerifyKey = "1145141919810",
                HttpSessionKey = "TEST KEY"
            };
        }

        [Fact]
        public async Task SendCorrectGetWithParams()
        {
            var parameters = MiraiHttpUtilities.ParseParameters(("test1", "value1"), ("test2", "value2"));
            var shoudbe = "?test1=value1&test2=value2";

            Assert.Equal(parameters, shoudbe);
            
            var url = $"https://httpbin.org/get{parameters}";
            var response = await _bot.GetHttp(url, true);

            var json = response.Fetch("args").ToJObject();
            var json1 = response.Fetch("headers").ToJObject();

            Assert.Contains("sessionkey", json1.ToString().ToLower());

            Assert.True(json.Fetch("test1") == "value1");
            Assert.True(json.Fetch("test2") == "value2");
        }

        [Fact]
        public async Task SendCorrectPostWithParams()
        {
            var parameters = MiraiHttpUtilities.ParseParameters(("test1", "value1"), ("test2", "value2"));
            var shoudbe = "?test1=value1&test2=value2";

            Assert.Equal(parameters, shoudbe);
            
            var url = $"https://httpbin.org/post{parameters}";
            var payload = new
            {
                TestK1 = "TestV1",
                TestK2 = "TestV2",
            };
            var response = await _bot.PostHttp(url, payload, true);

            var json = response.Fetch("args").ToJObject();
            var json1 = response.Fetch("headers").ToJObject();

            Assert.Contains("sessionkey", json1.ToString().ToLower());

            Assert.True(json.Fetch("test1") == "value1");
            Assert.True(json.Fetch("test2") == "value2");

            var json3 = response.Fetch("json");

            Assert.Equal(json3.ToJObject().ToString(), payload.ToJsonString());
        }
    }
}