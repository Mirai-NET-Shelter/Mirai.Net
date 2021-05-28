using System;
using Mirai.Net.Data.Events.Concrete.Args.Group;
using Mirai.Net.Utilities.Extensions;

namespace Mirai.Net
{
    public static partial class Bot
    {
        public static event Action<GroupNameChangedEventArgs> GroupNameChanged;

        private static void MatchGroupEvents(string data)
        {
            switch (data.ToJObject().GetPropertyValue("type"))
            {
                case "GroupNameChangeEvent":
                    GroupNameChanged?.Invoke(data.ToObject<GroupNameChangedEventArgs>());
                    break;
            }
        }
    }
}