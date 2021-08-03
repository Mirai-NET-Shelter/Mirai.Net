using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Modules;
using Mirai.Net.Sessions;

namespace Mirai.Net.Modules
{
    public interface ICommandModule
    {
        public bool? IsEnable { get; set; }
        
        [CommandTrigger(nameof(ICommandModule))]
        public void Execute(MiraiBot bot, MessageReceiverBase receiver, MessageBase executeMessage);
    }
}