using Mirai.Net.Data.Commands;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concrete;
using Mirai.Net.Messengers.Concrete;
using Mirai.Net.Modules.Commands;

namespace Mirai.Net.Test
{
    public class Test2Module : CommandModuleBase 
    {
        public override async void ExecuteCommand(MessageReceivedArgs args, string[] commandArgs)
        {
            if (args.Type == MessageReceivedArgs.MessageType.GroupMessage)
            {
                await new GroupMessenger(args.Sender.Group.Id).Send(
                    new PlainMessage($"Hello, World! parameters: {string.Join(" ", commandArgs)}"));
            }
        }

        public override Command Command { get; set; }
    }
}