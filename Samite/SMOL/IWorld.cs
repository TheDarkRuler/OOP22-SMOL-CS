using System.Collections.Concurrent;
using smol.stub;
namespace smol;

public interface IWorld
{
    List<IEntity> GetMoles();
    
    IEntity GetPlayer();
    
    List<IEntity> GetLifePlants();
    
    LinkedList<IEntity> GetEntities();
    
    void Remove(IEntity thisEntity);
    
    int GetScore();

    void AddEntity(IEntity thisEntity);
    
    void IncScore(int quantity);
    
    Dictionary<IEntity, bool> OccupiedPlants();
    
    void SetPlantFree(IEntity plant);
    
    void SetPlantOccupied(IEntity plant);

}