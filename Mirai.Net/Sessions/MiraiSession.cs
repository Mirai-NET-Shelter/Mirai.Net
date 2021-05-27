using System;
using System.Threading.Tasks;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json.Linq;

namespace Mirai.Net.Sessions
{
    public class MiraiSession
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string QQ { get; set; }
        public string Key { get; set; }

        public string SessionKey { get; private set; }
        
        private async Task<string> Authorize()
        {
            var url = $"http://{this.GetUrl()}/auth";
            var result = (await HttpUtility.Post(url, new
            {
                authKey = Key
            }.ToJson())).Content.ToJObject();

            if (result.GetPropertyValue("code") != "0")
            {
                throw new Exception(result.GetPropertyValue("msg"));
            }

            return result.GetPropertyValue("session");
        }

        private async Task Verify(string sessionKey)
        {
            var url = $"http://{this.GetUrl()}/verify";
            var result = (await HttpUtility.Post(url, new
            {
                sessionKey,
                qq = QQ
            }.ToJson())).Content.ToJObject();

            if (result.GetPropertyValue("code") != "0")
            {
                throw new Exception(result.GetPropertyValue("msg"));
            }
        }
        
        private async Task Release(string sessionKey)
        {
            var url = $"http://{this.GetUrl()}/release";
            var result = (await HttpUtility.Post(url, new
            {
                sessionKey,
                qq = QQ
            }.ToJson())).Content.ToJObject();
            
            if (result.GetPropertyValue("code") != "0")
            {
                throw new Exception(result.GetPropertyValue("msg"));
            }
        }
        
        public async Task Connect()
        {
            SessionKey = await Authorize();
            await Verify(SessionKey);
        }

        public async Task Disconnect()
        {
            await Release(SessionKey);
        }
    }
}