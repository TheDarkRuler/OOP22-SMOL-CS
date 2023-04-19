using System.Collections.Concurrent;
using smol.stub;
namespace smol;

public class WorldImpl : IWorld
{
    private const bool Occupied = true;
    private const bool Free = false;
    private LinkedList<IEntity> Entities { get; }
    private Dictionary<IEntity, bool> _occupiedPlants;
    private KeyInputs? _keyInputs = null;
    private int _score;
    public WorldImpl()
    {
        Entities = new LinkedList<IEntity>();
        this._occupiedPlants = new Dictionary<IEntity, bool>();
        _score = 0;
    }

    public List<IEntity> GetMoles()
    {
        return Entities.Where(entity => entity.GetType().Equals(EntityType.Enemy)).ToList();
    }

    public IEntity GetPlayer()
    {
        return Entities.First(entity => entity.GetType().Equals(EntityType.Player));
    }

    public List<IEntity> GetLifePlants()
    {
        return Entities.Where(entity => entity.GetType().Equals(EntityType.Health)).ToList();
    }

    public LinkedList<IEntity> GetEntities()
    {
        return Entities;
    }

    public void Remove(IEntity thisEntity)
    {
        Entities.Remove(thisEntity);
    }

    public int GetScore()
    {
        return _score;
    }

    public void UpdateWorld()
    {
        throw new NotImplementedException();
    }

    public void AddEntity(IEntity thisEntity)
    {
        Entities.AddFirst(thisEntity);
    }

    public void IncScore(int quantity)
    {
        _score = _score + quantity;
    }

    public Dictionary<IEntity, bool> OccupiedPlants(IEntity plant)
    {
        UpdateLifePlants();
        return new Dictionary<IEntity, bool>(this._occupiedPlants);
    }

    private void UpdateLifePlants()
    {
        foreach (var lifePlant in GetLifePlants())
        {
            _occupiedPlants.TryAdd(lifePlant, Free);
        }
        CheckRemoved();
    }

    private void CheckRemoved()
    {
        foreach (var lifePlant in _occupiedPlants.Keys)
        {
            if (!GetLifePlants().Contains(lifePlant))
            {
                _occupiedPlants.Remove(lifePlant);
            }
        }
    }
    public void SetPlantFree(IEntity plant)
    {
        UpdateLifePlants();
        if (_occupiedPlants.ContainsKey(plant))
        {
            _occupiedPlants.Add(plant,Free);
        }
    }

    public void SetPlantOccupied(IEntity plant)
    {
        UpdateLifePlants();
        if (_occupiedPlants.ContainsKey(plant))
        {
            _occupiedPlants.Add(plant,Occupied);
        }
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