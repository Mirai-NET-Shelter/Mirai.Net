using System;
using Mirai.Net.Data.Bot.Events.Concrete.Args;
using Mirai.Net.Utilities.Extensions;

// ReSharper disable once CheckNamespace
namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<BotMutedEventArgs> BotMuted;

        private static void MatchEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "BotMuteEvent":
                    BotMuted?.Invoke(data.ToObject<BotMutedEventArgs>());
                    break;
            }
        }
    }
}