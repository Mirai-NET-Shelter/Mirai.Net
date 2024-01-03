using Manganese.Text;
using System.Collections.Generic;
using System.Linq;

namespace Mirai.Net.Utils.Internal;

internal static class ExceptionUtils
{
    /// <summary>
    ///     获取状态码对应的原因
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    internal static string OfErrorMessage(this string json)
    {
        // todo: use is integer
        var code = json.Fetch("code")?.ThrowIfNotInt64("错误的状态码");

        return code switch
        {
            0 => "成功", // Success : StateCode(0, "success") // 成功
            1 => "错误的verify key", // AuthKeyFail : StateCode(1, "Auth Key错误")
            2 => "指定的Bot不存在", // NoBot : StateCode(2, "指定Bot不存在")
            3 => "Session失效或不存在", // IllegalSession : StateCode(3, "Session失效或不存在")
            4 => "Session未认证", // NotVerifySession : StateCode(4, "Session未认证")
            5 => "指定对象不存在", // NoElement : StateCode(5, "指定对象不存在")
            6 => "指定操作不支持", // NoOperateSupport : StateCode(6, "指定操作不支持")
            10 => "Bot没有对应操作的权限", // PermissionDenied : StateCode(10, "无操作权限")
            20 => "Bot被禁言", // BotMuted : StateCode(20, "Bot被禁言")
            30 => "消息过长", // MessageTooLarge : StateCode(30, "消息过长")
            400 => "无效参数", // InvalidParameter : StateCode(400, "无效参数")
            500 => "内部错误", // class InternalError() : StateCode(500, "")
            _ => null // default case if code does not match any known codes
        };
    }

}