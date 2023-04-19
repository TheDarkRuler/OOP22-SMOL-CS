using Xunit;
using smol;
namespace World.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var p = new Point2D(5, 9);
        Assert.Equal(5.0, p.X);
    }
}