namespace SMOL_PlantsCreationTest;
using PlantsCreation;
using GameHitBox;

///<summary>
///Test class that tests if the PlantsCreation class creates correctly the right number of plants and none of them
///collide with eachother.
///</summary>
public class PlantsCreationTest
{

    ///<summary>
    ///Tests if the right number of plants are created and they do not collide.
    ///</summary>
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