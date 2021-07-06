using System;using System.Collections.Generic;
using System.Linq;
using Mirai.Net.Data.Events;
using Mirai.Net.Data.Events.Bot;
using Mirai.Net.Data.Events.Friend;
using Mirai.Net.Data.Events.Group;
using Mirai.Net.Data.Message;
using Mirai.Net.Data.Message.Args;
using Mirai.Net.Data.Message.Concrete;
using Mirai.Net.Listeners;
using Mirai.Net.Managers;
using Mirai.Net.Sessions;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    public class TestListener : IMessageListener
    {
        public IEnumerable<MessageReceiveType> Executors { get; set; } = new[]
        {
            MessageReceiveType.Friend
        };

        public async void Execute(MessageArgs args, MiraiBot bot)
        {
            if (args is FriendMessageArgs friendMessageArgs)
            {
                var messenger = new Messenger(bot);

                await messenger.SendFriendMessage(friendMessageArgs.Sender.Id, friendMessageArgs.Chain.ToArray());
            }
        }
    }
}