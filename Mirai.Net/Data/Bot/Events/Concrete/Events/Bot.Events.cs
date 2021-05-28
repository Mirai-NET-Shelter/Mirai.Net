using System;
using Mirai.Net.Data.Bot.Events.Concrete.Args;

// ReSharper disable once CheckNamespace
namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<BotMutedEventArgs> BotMuted;
    }
}