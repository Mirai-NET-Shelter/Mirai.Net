using Mirai.Net.Data.Messages;

namespace Mirai.Net.Modules
{
    public interface IModule
    {
        public void Execute(MessageReceivedArgs args);
    }
}