using System;
using System.Linq;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;

namespace Mirai.Net.Test
{
    public class Module1 : IModule
    {
        public async void Execute(MessageReceiverBase @base)
        {
            var receiver = @base.Concretize<GroupMessageReceiver>();
            if (receiver.Sender.Id != "2933170747")
            {
                return;
            }
            var plain = receiver.MessageChain.GetPlainMessage();
            if (plain == "/off")
            {
                IsEnable = false;
                await receiver.SendMessageAsync("Current module will be turned off");
                return;
            }
            
            await receiver.SendMessageAsync(plain);
        }

        public bool? IsEnable { get; set; }
    }
}