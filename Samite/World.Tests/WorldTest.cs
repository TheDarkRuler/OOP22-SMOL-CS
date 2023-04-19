using Xunit;
using smol;
using smol.stub;
namespace World.Tests;

public class WorldTest
{
    [Fact]
    public void EmptyWorldTesting()
    {
        IWorld world = new WorldImpl();
        Assert.Empty(world.GetMoles());
        Assert.Empty(world.GetEntities());
        Assert.Equal(0, world.GetScore());
    }

    [Fact]
    public void SimpleWorldTesting()
    {
        IWorld world = new WorldImpl();
        var plant = new EntityImpl(EntityType.Health);
        var player = new EntityImpl(EntityType.Player);
        var mole = new EntityImpl(EntityType.Enemy);
        world.IncScore(100);
        world.AddEntity(player);
        world.AddEntity(plant);
        world.AddEntity(mole);
        //basic Enemies testing
        Assert.Contains(mole, world.GetMoles());
        Assert.DoesNotContain(plant, world.GetMoles());
        //player testing
        Assert.Equal(player, world.GetPlayer());
        //basic plants testing
        Assert.Contains(plant, world.GetLifePlants());
        Assert.DoesNotContain(mole, world.GetLifePlants());
        //basic score testing
        Assert.Equal(100, world.GetScore());
        world.IncScore(2000);
        Assert.NotEqual(100, world.GetScore());
        Assert.Equal(2100, world.GetScore());
        //remove
        world.Remove(plant);
        Assert.Empty(world.GetLifePlants());
    }
    
    [Fact]
    public void PlantTesting()
    {
        IWorld world = new WorldImpl();
    }
}