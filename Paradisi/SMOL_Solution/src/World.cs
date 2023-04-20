namespace MySpace;
using System.Collections.Concurrent;
using System.Collections.Generic;

class World : IWorld
{
    private List<IEntity> _entities;
    private int _score;

    public World()
    {
        _entities = new List<IEntity>();
        _score = 0;
    }

    public void AddEntity(IEntity thisEntity)
    {
        _entities.Add(thisEntity);
    }

    public ConcurrentQueue<IEntity> GetEntities()
    {
        return new ConcurrentQueue<IEntity>(_entities);
    }

    public int GetScore() => _score;

    public void IncScore(int quantity)
    {
        _score += quantity;
    }

    public void Remove(IEntity thisEntity)
    {
        _entities.Remove(thisEntity);
    }
}