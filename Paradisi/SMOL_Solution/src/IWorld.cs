using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GameState;

public interface IWorld
{   
    ConcurrentQueue<IEntity> GetEntities();
    
    void Remove(IEntity thisEntity);

    int GetScore();

    void AddEntity(IEntity thisEntity);
    
    void IncScore(int quantity);
}