using System;

namespace Mirai.Net.Data.Modules
{
    /// <summary>
    /// <example>
    /// /hello --arg1 value1 value2 --arg2 --arg3
    /// <para>/: prefix</para>
    /// <para>hello : name</para>
    /// <para>-- : args separator</para>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class CommandTriggerAttribute : Attribute
    {
        public string Prefix { get; set; }

        public string Name { get; set; }

        public string ArgsSeparator { get; set; }

        /// <summary>
        /// 命令中是否只能包含Name
        /// </summary>
        public bool EqualName { get; set; }

        public CommandTriggerAttribute(string name, string prefix = "/", string argsSeparator = "-", bool equalName = false)
        {
            Prefix = prefix;
            Name = name;
            ArgsSeparator = argsSeparator;
            EqualName = equalName;
        }
    }
}