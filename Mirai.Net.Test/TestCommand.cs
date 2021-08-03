using CommandLine;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Test
{
    [Verb("/test", HelpText = "test command")]
    public class TestCommand
    {
        public async void Executed(MiraiBot bot, MessageBase messageBase, MessageReceiverBase receiver)
        {
            if (receiver is GroupMessageReceiver groupReceiver)
            {
                await bot.GetManager<MessageManager>().SendGroupMessage(groupReceiver.Sender.Group.Id, "Tested!".Append());
            }
        }
    }
}