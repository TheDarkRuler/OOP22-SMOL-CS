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
    
    void UpdateWorld();
    
    void AddEntity(IEntity thisEntity);
    
    void IncScore(int quantity);
    
    Dictionary<IEntity, bool> OccupiedPlants(IEntity plant);
    
    void SetPlantFree(IEntity plant);
    
    void SetPlantOccupied(IEntity plant);

    KeyInputs GetKeyInputs();

    void SetInputs(KeyInputs keyInputs);
    
}