using System.Collections.Generic;
using CommandLine;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    [Verb("/general", HelpText = "general command")]
    public class GeneralCommand
    {
        [Option("names")]
        public IEnumerable<string> Names { get; set; }

        public async void Executed(MiraiBot bot, MessageBase messageBase, MessageReceiverBase receiver)
        {
            if (receiver is GroupMessageReceiver groupMessage)
            {
                var mgr = bot.GetManager<MessageManager>();

                await mgr.SendGroupMessage(groupMessage.Sender.Group.Id, string.Join(" ", Names).Append());
            }
        }
    }
}