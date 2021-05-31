using Mirai.Net.Data.Commands;
using Mirai.Net.Data.Messages;

namespace Mirai.Net.Modules.Commands
{
    public abstract class CommandModuleBase : IModule
    {
        public virtual void Execute(MessageReceivedArgs args)
        {
            //do nothing unless user implement this
        }

        public abstract void ExecuteCommand(MessageReceivedArgs args, string[] commandArgs);

        public abstract Command Command { get; set; }
    }
}