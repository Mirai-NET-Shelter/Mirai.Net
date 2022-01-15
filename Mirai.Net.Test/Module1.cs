using System;
using System.Linq;
using Mirai.Net.Data.Commands;
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

            if (plain.CanExecute<SayCommand>())
            {
                var command = receiver.MessageChain.GetPlainMessage().ParseCommand<SayCommand>();
                await receiver.SendMessageAsync(command.Value);
            }
            
        }

        public bool? IsEnable { get; set; }

        [CommandEntity(Name = "say", Identifier = "/")]
        class SayCommand
        {
            [CommandArgument(Name = "v", IsRequired = true)]
            public string Value { get; set; }
        }
    }
}