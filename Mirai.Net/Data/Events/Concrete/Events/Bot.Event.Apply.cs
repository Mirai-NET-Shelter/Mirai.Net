using System;
using Mirai.Net.Data.Events.Concrete.Args.Apply;
using Mirai.Net.Data.Events.Concrete.Args.Group;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<NewFriendApplyEventArgs> ReceivedFriendRequest;
        public static event Action<MemberJoinApplyEventArgs> ReceivedGroupJoinRequest;
        public static event Action<BotInvitedEventArgs> ReceivedGroupInvited;
        
        private static void MatchApplyEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "NewFriendRequestEvent":
                    ReceivedFriendRequest?.Invoke(data.ToObject<NewFriendApplyEventArgs>());
                    break;
                case "MemberJoinRequestEvent":
                    ReceivedGroupJoinRequest?.Invoke(data.ToObject<MemberJoinApplyEventArgs>());
                    break;
                case "BotInvitedJoinGroupRequestEvent":
                    ReceivedGroupInvited?.Invoke(data.ToObject<BotInvitedEventArgs>());
                    break;
            }
        }
    }
}