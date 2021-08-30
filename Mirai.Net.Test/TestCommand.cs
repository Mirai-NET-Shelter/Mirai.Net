using System.Windows.Input;
using CommandLine;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Sessions;
using Mirai.Net.Sessions.Http.Concretes;
using Mirai.Net.Utils.Extensions;
using Mirai.Net.Utils.Extensions.Actions;

namespace Mirai.Net.Test
{
    public class TestCommand : IModule
    {
        public bool? IsEnable { get; set; }
        
        [CommandTrigger("hello")]
        public async void Execute(MessageReceiverBase receiver, MessageBase executeMessage)
        {
            if (receiver is GroupMessageReceiver groupMessageReceiver)
            {
                await groupMessageReceiver.SendGroupMessage("Hello, World!".Append());
            }
        }
    }
}