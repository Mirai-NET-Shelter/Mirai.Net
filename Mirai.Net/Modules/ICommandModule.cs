using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Modules;

namespace Mirai.Net.Modules
{
    public interface ICommandModule
    {
        public bool? IsEnable { get; set; }
        
        [CommandTrigger(nameof(ICommandModule))]
        public void Execute(MessageReceiverBase receiver, MessageBase executeMessage);
    }
}