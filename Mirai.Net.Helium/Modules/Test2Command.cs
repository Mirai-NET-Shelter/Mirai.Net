using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Helium.Modules
{
    public class Test2Command : ICommandModule
    {
        public bool? IsEnable { get; set; }

        [CommandTrigger("github.com", "", EqualName = false)]
        public async void Execute(MiraiBot bot, MessageReceiverBase receiver, MessageBase executeMessage)
        {
            var mgr = bot.GetManager<MessageManager>();

            if (receiver is GroupMessageReceiver groupMessageReceiver)
            {
                var target = groupMessageReceiver.Sender.Group.Id;

                await mgr.SendGroupMessage(target, "tested!".Append());
            }
        }
    }
}