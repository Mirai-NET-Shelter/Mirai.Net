using System;
using Mirai.Net.Data.Events.Concrete.Args.Message;
using Mirai.Net.Utilities.Extensions;

// ReSharper disable once CheckNamespace
namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<GroupMessageRecalledEventArgs> GroupMessageRecalled;

        private static void MatchBotMessageEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "GroupRecallEvent":
                    GroupMessageRecalled?.Invoke(data.ToObject<GroupMessageRecalledEventArgs>());
                    break;
                
            }
        }
    }
}