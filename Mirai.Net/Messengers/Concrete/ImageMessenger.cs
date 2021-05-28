using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Enums;
using Mirai.Net.Data.Messengers.Enums;
using Mirai.Net.Utilities;
using Mirai.Net.Utilities.Extensions;
using Newtonsoft.Json;

namespace Mirai.Net.Messengers.Concrete
{
    public class ImageMessenger : MessengerBase
    {
        public string QQ { get; set; }
        public string Group { get; set; }

        public ImageMessenger(string qq = null, string group = null)
        {
            QQ = qq;
            Group = group;
        }
       

        public async Task<IEnumerable<string>> Send(params string[] images)
        {
            var url = $"{Bot.Session.GetUrl()}/sendImageMessage";

            var result = (await HttpUtility.Post(url, JsonConvert.SerializeObject(new
            {
                sessionKey = Bot.Session.SessionKey,
                qq = QQ,
                group = Group,
                urls = images
            }, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            }))).Content;

            return result.ToObject<string[]>();
        }
        public override Task<MessageCallback> Send(params MessageBase[] message)
        {
            throw new System.NotImplementedException();
        }
        public override Task<MessageCallback> Send(string messageId, params MessageBase[] message)
        {
            throw new System.NotImplementedException();
        }
    }
}