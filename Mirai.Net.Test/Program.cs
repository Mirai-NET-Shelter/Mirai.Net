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
        
        [Fact]
        internal void ToObject()
        {
            var obj = new MyClass
            {
                Name = "Ahpx",
                Identify = "114514"
            };

            var otj = obj.ToJson().ToObject<MyClass>();
            var jto = otj.ToJson();

            Assert.True(otj.Name == jto.ToObject<MyClass>().Name);
        }
    }

    class MyClass
    {
        public string Name { get; set; }
        public string Identify { get; set; }
    }
}