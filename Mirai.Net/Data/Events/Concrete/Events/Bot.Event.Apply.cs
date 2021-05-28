using System;
using Mirai.Net.Data.Events.Concrete.Args.Apply;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<NewFriendApplyEventArgs> ReceivedFriendRequest;
        
        private static void MatchApplyEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "NewFriendRequestEvent":
                    ReceivedFriendRequest?.Invoke(data.ToObject<NewFriendApplyEventArgs>());
                    break;
            }
        }
    }
}