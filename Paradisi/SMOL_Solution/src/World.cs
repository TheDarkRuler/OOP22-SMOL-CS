namespace MySpace;
using System.Collections.Concurrent;
using System.Collections.Generic;
///<summary>
///The implementation of world interface.
///</summary>
public class World : IWorld
{
    private List<Entity> _entities;
    private int _score;

    ///<summary>
    ///Set the list of entities and the score.
    ///</summary>
    public World()
    {
        _entities = new List<Entity>();
        _score = 0;
    }

    ///<inheritdoc />
    public void AddEntity(Entity thisEntity)
    {
        _entities.Add(thisEntity);
    }

    ///<inheritdoc />
    public ConcurrentQueue<Entity> GetEntities()
    {
        return new ConcurrentQueue<Entity>(_entities);
    }

    ///<inheritdoc />
    public int GetScore() => _score;

    ///<inheritdoc />
    public void IncScore(int quantity)
    {
        _score = _score + quantity;
    }

    ///<inheritdoc />
    public void Remove(Entity thisEntity)
    {
        _entities.Remove(thisEntity);
    }
}