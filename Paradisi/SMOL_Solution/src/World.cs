namespace MySpace;
using System.Collections.Concurrent;
using System.Collections.Generic;

public class World : IWorld
{
    private List<Entity> _entities;
    private int _score;

    public World()
    {
        _entities = new List<Entity>();
        _score = 0;
    }

    public void AddEntity(Entity thisEntity)
    {
        _entities.Add(thisEntity);
    }

    public ConcurrentQueue<Entity> GetEntities()
    {
        return new ConcurrentQueue<Entity>(_entities);
    }

    public int GetScore() => _score;

    public void IncScore(int quantity)
    {
        _score = _score + quantity;
    }

    public void Remove(Entity thisEntity)
    {
        _entities.Remove(thisEntity);
    }
}