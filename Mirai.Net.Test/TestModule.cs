using System.Runtime.InteropServices;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Messengers.Concrete;
using Mirai.Net.Modules;

namespace Mirai.Net.Test
{
    public class TestModule : IModule
    {
        public async void Execute(MessageReceivedArgs args)
        {
            if (args.Type == MessageReceivedArgs.MessageType.FriendMessage)
            {
                var messenger = new FriendMessenger("2933170747");

                await messenger.Send(new PlainMessage($"Hello, {args.Sender.Id}"));
            }   
        }
    }
}