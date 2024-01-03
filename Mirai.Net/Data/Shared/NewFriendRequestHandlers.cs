namespace Mirai.Net.Data.Shared;

/// <summary>
/// 好友请求处理
/// </summary>
public enum NewFriendRequestHandlers
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
    /// 拒绝并屏蔽
    /// </summary>
    RejectAndBlock = 2
}