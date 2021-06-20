using System;
using Newtonsoft.Json;

namespace Mirai.Net.Data.Events.Bot
{
    public class BotEvent
    {
        public event Action<BotEventArgs> Online;
        public event Action<BotEventArgs> Offline;
        public event Action<BotEventArgs> OfflinePassive;
        public event Action<BotEventArgs> Dropped;
        public event Action<BotEventArgs> Relogin;
    }

    public class BotEventArgs : EventArgsBase
    {
        [JsonProperty("qq")]
        public string QQ {get; private set;}
    }
}