namespace SMOL_PlantsCreationTest;
using PlantsCreation;
using GameHitBox;

public class PlantsCreationTest
{
    [Fact]
    public void CreationTest()
    {
        var plantCreation = new PlantsCreation();
        Assert.Equal(plantCreation.Entities.Count, plantCreation.NumPlants);
        foreach (var entity in plantCreation.Entities)
        {
            foreach (var item in plantCreation.Entities)
            {
                if (entity != item)
                {
                    var entityHB = new RectangleHB(entity, plantCreation.PlantWidth, plantCreation.PlantHeight);
                    var itemHB = new RectangleHB(item, plantCreation.PlantWidth, plantCreation.PlantHeight);
                    Assert.False(entityHB.IsColliding(itemHB));
                }
            }
        }
    }
}