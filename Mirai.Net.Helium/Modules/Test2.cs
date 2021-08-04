using System.Linq;
using System.Reflection;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Actions;

namespace Mirai.Net.Helium.Modules
{
    public class Test2 : IModule
    {
        public bool? IsEnable { get; set; } = false;

        [CommandTrigger("github.com", "", EqualName = false)]
        public async void Execute(MessageReceiverBase receiver, MessageBase executeMessage)
        {
            if (receiver is GroupMessageReceiver groupMessageReceiver)
            {
                foreach (var message in receiver.MessageChain.WhereAndCast<PlainMessage>())
                {
                    var command = this.ParseCommand(message.Text);

                    if (command.Count != 0)
                    {
                        await groupMessageReceiver.SendGroupMessage(
                            $"{command.First().Key} - {string.Join(' ', command.First().Value)}".Append());
                    }
                }
            }
        }
    }
}