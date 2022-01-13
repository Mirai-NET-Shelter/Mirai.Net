using System;

namespace Mirai.Net.Data.Commands;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public class CommandArgumentAttribute : Attribute
{
    /// <summary>
    /// 参数名，比如"arg1"之于"/test -arg1"
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 参数是否为必须，如果是必须参数不填会报错，与Default冲突，二者选其一
    /// </summary>
    public bool IsRequired { get; set; } = false;

    /// <summary>
    /// 参数的默认值，与IsRequired冲突，二者选其一
    /// </summary>
    public object Default { get; set; } = null;
}