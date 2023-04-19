using System.Collections.Concurrent;

namespace smol;

public class WorldImpl : IWorld
{
    public List<IEntity> GetMoles()
    {
        throw new NotImplementedException();
    }

    public IEntity GetPlayer()
    {
        throw new NotImplementedException();
    }

    public List<IEntity> GetLifePlants()
    {
        throw new NotImplementedException();
    }

    public ConcurrentQueue<IEntity> GetEntities()
    {
        throw new NotImplementedException();
    }

    public void Remove(IEntity thisEntity)
    {
        throw new NotImplementedException();
    }

    public int GetScore()
    {
        throw new NotImplementedException();
    }

    public void UpdateWorld()
    {
        throw new NotImplementedException();
    }

    public void AddEntity(IEntity thisEntity)
    {
        throw new NotImplementedException();
    }

    public void IncScore(int quantity)
    {
        throw new NotImplementedException();
    }

    public Dictionary<IEntity, bool> OccupiedPlants(IEntity plant)
    {
        throw new NotImplementedException();
    }

    public void SetPlantFree(IEntity plant)
    {
        throw new NotImplementedException();
    }

    public void SetPlantOccupied(IEntity plant)
    {
        throw new NotImplementedException();
    }

    public KeyInputs GetKeyInputs()
    {
        throw new NotImplementedException();
    }

    public void SetInputs(KeyInputs keyInputs)
    {
        throw new NotImplementedException();
    }
}