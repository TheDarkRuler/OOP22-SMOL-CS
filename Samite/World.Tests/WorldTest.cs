using System;
using System.Linq;
using Xunit;
using smol;
using smol.stub;
using Xunit.Abstractions;

namespace World.Tests;

/// <summary>
/// Tests for the World. 
/// </summary>
public class WorldTest
{
    private readonly ITestOutputHelper _testOutputHelper;
    private int _freePlants = 0;

    public WorldTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

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
        var plant = new EntityImpl(EntityType.Health, new HealthComponent());
        var player = new EntityImpl(EntityType.Player, null);
        var mole = new EntityImpl(EntityType.Enemy, null);
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
        var plant1 = new EntityImpl(EntityType.Health, new HealthComponent());
        var plant2 = new EntityImpl(EntityType.Health, new HealthComponent());
        var plant3 = new EntityImpl(EntityType.Health, new HealthComponent());
        var plant4 = new EntityImpl(EntityType.Health, new HealthComponent());
        world.AddEntity(plant1);
        world.AddEntity(plant2);
        world.AddEntity(plant3);
        world.AddEntity(plant4);
        foreach (var lifePlant in world.GetLifePlants())
        {
            Assert.Contains(lifePlant, world.OccupiedPlants().Keys);
        }
        world.SetPlantOccupied(plant1);
        Assert.Equal(3, CountFreePlants(world));
        world.SetPlantOccupied(new EntityImpl(EntityType.Health, new HealthComponent()));
        Assert.Equal(3, CountFreePlants(world));
        world.SetPlantFree(plant1);
        Assert.Equal(4, CountFreePlants(world));
    }

    /// <summary>
    /// Counter of free plants
    /// </summary>
    /// <param name="currentWorld">
    /// current world where i want to find the number of free plants
    /// </param>
    /// <returns>free plants</returns>
    private int CountFreePlants(IWorld currentWorld)
    {
        _freePlants = 0;
        foreach (var occupied in currentWorld.OccupiedPlants().Values.Where(occupied => !occupied))
        {
            _freePlants++;
        }
        return _freePlants;
    }
}