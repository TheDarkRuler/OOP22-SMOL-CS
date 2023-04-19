using Xunit;
using smol;
using smol.stub;
namespace World.Tests;

public class HealthBarTest
{
    [Fact]
    public void EmptyWorldTesting()
    {
        IWorld world = new WorldImpl();
        Assert.Empty(world.GetMoles());
        Assert.Empty(world.GetEntities());
        Assert.Equal(0, world.GetScore());
    }

}