using Mirai.Net.Data.Messages;

namespace Mirai.Net.Modules;

public interface IModule
{
    void Execute(MessageReceiverBase @base);
    bool? IsEnable { get; set; }
}