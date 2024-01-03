using Mirai.Net.Data.Messages;

namespace Mirai.Net.Modules;

/// <summary>
/// 模块化接口
/// </summary>
public interface IModule
{
    /// <summary>
    /// 执行器
    /// </summary>
    /// <param name="base"></param>
    void Execute(MessageReceiverBase @base);

    /// <summary>
    /// 是否启用模块
    /// </summary>
    bool? IsEnable { get; set; }
}