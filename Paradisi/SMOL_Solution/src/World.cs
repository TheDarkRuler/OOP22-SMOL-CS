using System.Collections.Concurrent;

namespace SMOL_Solution;

class World : IWorld
{
    private int _score = 0;

    public void AddEntity(IEntity thisEntity)
    {
        throw new NotImplementedException();
    }

    public ConcurrentQueue<IEntity> GetEntities()
    {
        throw new NotImplementedException();
    }

    public List<IEntity> GetLifePlants()
    {
        throw new NotImplementedException();
    }

    public IEntity GetPlayer()
    {
        throw new NotImplementedException();
    }

    public int GetScore() => _score;

    public void IncScore(int quantity)
    {
        _score += quantity;
    }

    public void Remove(IEntity thisEntity)
    {
        throw new NotImplementedException();
    }
}