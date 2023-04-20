namespace MySpace;
using System.Collections.Concurrent;
using System.Collections.Generic;

public interface IWorld
{   
    ConcurrentQueue<Entity> GetEntities();
    
    void Remove(Entity thisEntity);

    int GetScore();

    void AddEntity(Entity thisEntity);
    
    void IncScore(int quantity);
}