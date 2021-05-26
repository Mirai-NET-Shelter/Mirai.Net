using System;
using Mirai.Net.Utilities.Extensions;
using Xunit;

namespace Mirai.Net.Test
{
    public class Program
    {
        [Theory]
        [InlineData(typeof(MyClass))]
        internal void ToJson(Type type)
        {
            type.ToJson();
        }
    }

    class MyClass
    {
        public string Name { get; set; }
        public string Identify { get; set; }
    }
}