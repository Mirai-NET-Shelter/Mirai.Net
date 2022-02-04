using System;
using System.Linq;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Messages.Concretes;
using Mirai.Net.Data.Messages.Receivers;
using Mirai.Net.Data.Modules;
using Mirai.Net.Modules;
using Mirai.Net.Utils.Scaffolds;

namespace Mirai.Net.Test
{
    public class Module1 : IModule
    {
        public async void Execute(MessageReceiverBase @base)
        {
            var receiver = @base.Concretize<GroupMessageReceiver>();
            var plain = receiver.MessageChain.GetPlainMessage();

        }

        public bool? IsEnable { get; set; }
    }
}