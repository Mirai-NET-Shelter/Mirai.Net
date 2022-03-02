namespace Mirai.Net.Data.Shared;

/// <summary>
/// 新成员进群处理
/// </summary>
public enum NewMemberRequestHandlers
{
    /// <summary>
    /// 同意
    /// </summary>
    Approve = 0,
    /// <summary>
    /// 拒绝
    /// </summary>
    Reject = 1,
    /// <summary>
    /// 忽略
    /// </summary>
    Dismiss = 2,
    /// <summary>
    /// 拒绝并拉黑
    /// </summary>
    RejectAndBlock = 3,
    /// <summary>
    /// 忽略
    /// </summary>
    DismissAndBlock = 4
}