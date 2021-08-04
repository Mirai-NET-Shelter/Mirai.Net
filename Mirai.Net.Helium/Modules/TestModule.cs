using System.Linq;
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
    public class TestModule : IModule
    {
        public bool? IsEnable { get; set; }

        [CommandTrigger("test", equalName: true)]
        public async void Execute(MessageReceiverBase receiver, MessageBase executeMessage)
        {
            if (receiver is GroupMessageReceiver groupMessageReceiver)
            {
                foreach (var message in groupMessageReceiver.MessageChain.WhereAndCast<PlainMessage>())
                {
                    var parse = this.ParseCommand(message.Text);
                    await groupMessageReceiver
                        .SendGroupMessage("tested by "
                            .Append($"{parse.First().Key}")
                            .Append(" - ")
                            .Append($"{string.Join(" ", parse.First().Value)}"));
                }
            }
        }
    }
}