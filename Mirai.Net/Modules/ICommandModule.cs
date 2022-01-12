using System;
using Mirai.Net.Data.Messages;
using Mirai.Net.Data.Modules;

namespace Mirai.Net.Modules;

[Obsolete("请使用IModule以体验全新的命令-模块系统")]
public interface ICommandModule
{
    public bool? IsEnable { get; set; }

    [CommandTrigger(nameof(ICommandModule))]
    public void Execute(MessageReceiverBase receiver, MessageBase executeMessage);
}