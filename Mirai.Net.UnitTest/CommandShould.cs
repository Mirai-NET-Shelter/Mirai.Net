using Mirai.Net.Data.Commands;
using Mirai.Net.Utils.Scaffolds;
using Xunit;

namespace Mirai.Net.UnitTest;

public class CommandShould
{
    [Theory]
    [InlineData("/test -arg1 awkdj awd awd awd -arg2 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4")]
    [InlineData("/test -arg1 -arg2 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4")]
    [InlineData("/test -arg1 1234 -arg2 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4")]
    [InlineData("/test")]
    [InlineData("/test-arg3")]
    [InlineData("/test-arg1 awkdj awd awd awd-arg21-arg3akwjdh kjawhd akjwhd akjwh-arg4")]
    [InlineData("/test-arg4")]
    [InlineData("/test-arg4 awd awd")]
    [InlineData("/test-arg4 awd awd -arg5 114.514")]
    public void CanExecute(string command)
    {
        Assert.True(command.CanExecute<TestClass>());
    }
    
    [Theory]
    [InlineData("a/test1 -arg1 awkdj awd awd awd -arg2 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4")]
    [InlineData("/test1 -arg1 awkdj awd awd awd -arg2 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4")]
    [InlineData("/test 1 -arg3 akwjdh kjawhd akjwhd akjwh -arg4")]
    [InlineData("/test -arg2 1234124313241234234234123413412342q341341234123412341234 -arg4")]
    [InlineData("/test -arg2 a -arg4 -arg5 114.514a")]
    [InlineData("/test -arg2 a -arg4 -arg5 awd")]
    public void CantExecute(string command)
    {
        Assert.False(command.CanExecute<TestClass>());
    }

    [CommandEntity(Name = "test")]
    class TestClass
    {
        [CommandArgument(Name = "arg1")]
        public string Arg1 { get; set; }

        [CommandArgument(Name = "arg2")]
        public int Arg2 { get; set; }

        [CommandArgument(Name = "arg3")]
        public string[] Arg3 { get; set; }

        [CommandArgument(Name = "arg4")]
        public bool Arg4 { get; set; }
        
        [CommandArgument(Name = "arg5")]
        public double Arg5 { get; set; }
    }
    
    [CommandEntity(Name = "test")]
    class DefaultClass
    {
        [CommandArgument(Name = "arg4", IsRequired = true)]
        public bool Arg4 { get; set; }
    }
    
    [Fact]
    public void CantExecuteDefault()
    {
        Assert.False("/test -arg4".CanExecute<DefaultClass>());
    }
    
}