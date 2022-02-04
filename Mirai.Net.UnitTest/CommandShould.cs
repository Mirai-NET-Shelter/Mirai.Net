
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
        
    }

    [Fact]
    public void CantExecuteDefault()
    {
        
    }
    
}