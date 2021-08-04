using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Modules;
using Mirai.Net.Sessions;

namespace Mirai.Net.Modules
{
    public interface IModule
    {
        public bool? IsEnable { get; set; }
        
        [CommandTrigger(nameof(IModule))]
        public void Execute(MessageReceiverBase receiver, MessageBase executeMessage);
    }
}