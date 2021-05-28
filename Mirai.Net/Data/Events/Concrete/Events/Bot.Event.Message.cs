using System;
using Mirai.Net.Data.Events.Concrete.Args.Message;
using Mirai.Net.Utilities.Extensions;

// ReSharper disable once CheckNamespace
namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<GroupMessageRecalledEventArgs> GroupMessageRecalled;
        public static event Action<FriendMessageRecalledEventArgs> FriendMessageRecalled;
        public static event Action<NudgeEventArgs> ReceivedNudge;

        private static void MatchBotMessageEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "GroupRecallEvent":
                    GroupMessageRecalled?.Invoke(data.ToObject<GroupMessageRecalledEventArgs>());
                    break;
                case "FriendRecallEvent":
                    FriendMessageRecalled?.Invoke(data.ToObject<FriendMessageRecalledEventArgs>());
                    break;
                case "NudgeEvent":
                    ReceivedNudge?.Invoke(data.ToObject<NudgeEventArgs>());
                    break;
            }
        }
    }
}