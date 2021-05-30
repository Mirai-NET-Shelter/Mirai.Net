using Mirai.Net.Data.Commands;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Modules.Commands
{
    public abstract class CommandModuleBase : IModule
    {
        public abstract void Execute(MessageReceivedArgs args);

        public abstract void ExecuteCommand(MessageReceivedArgs args, string[] commandArgs);

        public abstract Command Command { get; set; }
    }
}