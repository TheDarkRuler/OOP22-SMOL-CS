using System.Collections.Concurrent;

namespace SMOL_Solution;

public interface IWorld
{   
    IEntity GetPlayer();

    List<IEntity> GetLifePlants();

    ConcurrentQueue<IEntity> GetEntities();
    
    void Remove(IEntity thisEntity);

    int GetScore();

    void AddEntity(IEntity thisEntity);
    
    void IncScore(int quantity);
}