using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;

namespace Mirai.Net.Helium.Modules
{
    public class TestModule : IModule
    {
        public bool? IsEnable { get; set; }

        [CommandTrigger("test", equalName: true)]
        public async void Execute(MessageReceiverBase receiver, MessageBase executeMessage)
        {
            var mgr = MiraiBotFactory.Bot.GetManager<MessageManager>();

            if (receiver is GroupMessageReceiver groupMessageReceiver)
            {
                var target = groupMessageReceiver.Sender.Group.Id;

                await mgr.SendGroupMessage(target, "tested!".Append());
            }
        }
    }
}