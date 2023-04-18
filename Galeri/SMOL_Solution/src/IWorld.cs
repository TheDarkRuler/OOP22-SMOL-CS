using System.Collections.Concurrent;

namespace SMOL_Solution;

public interface IWorld
{
 
    List<IEntity> GetMoles();
    
    IEntity GetPlayer();

    List<IEntity> GetLifePlants();

    ConcurrentQueue<IEntity> GetEntities();
    
    void Remove(IEntity thisEntity);

    int GetScore();

    void UpdateWorld();

    void AddEntity(IEntity thisEntity);

    void AddFirstEntity(IEntity thisEntity);
    
    void IncScore(int quantity);

    void SetPlantFree(IEntity plant);
    
    void SetPlantOccupied(IEntity plant);

}