using System;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Bot
{
    public class BotEventArgs : EventArgsBase
    {
        [JsonProperty("qq")]
        public string QQ {get; private set;}
    }
}