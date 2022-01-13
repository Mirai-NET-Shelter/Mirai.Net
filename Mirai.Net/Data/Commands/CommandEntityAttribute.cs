using System;

namespace Mirai.Net.Data.Commands;

[AttributeUsage(AttributeTargets.Class)]
public class CommandEntityAttribute : Attribute
{
    /// <summary>
    /// 此命令的正式名称，比如"test"之于"/test"
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 此命令的别名，比如"/t"和"/tst"等价于"/test"
    /// </summary>
    public string[] Alias { get; set; } = { };

    /// <summary>
    /// 命令参数分隔符，比如"-"之于"/test -arg1 xxx -arg2 yyy""，默认为"-"
    /// </summary>
    public string Separator { get; set; } = "-";

    /// <summary>
    /// 命令的标识符，比如"/"之于"/test"，默认为"/"
    /// </summary>
    public string Identifier { get; set; } = "/";
}