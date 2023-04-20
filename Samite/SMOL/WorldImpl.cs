using System.Collections.Concurrent;
using smol.stub;
namespace smol;
/// <summary>
/// World implementation
/// </summary>
public class WorldImpl : IWorld
{
    private const bool Occupied = true;
    private const bool Free = false;
    private LinkedList<IEntity> Entities { get; }
    private Dictionary<IEntity, bool> OccPlants { get; }
    private int _score;
    
    /// <summary>
    /// constructor for game world.
    /// </summary>
    public WorldImpl()
    {
        Entities = new LinkedList<IEntity>();
        this.OccPlants = new Dictionary<IEntity, bool>();
        _score = 0;
    }
    
    /// <inheritdoc />
    public List<IEntity> GetMoles()
    {
        return Entities.Where(entity => entity.GetType().Equals(EntityType.Enemy)).ToList();
    }

    /// <inheritdoc />
    public IEntity GetPlayer()
    {
        return Entities.First(entity => entity.GetType().Equals(EntityType.Player));
    }

    /// <inheritdoc />
    public List<IEntity> GetLifePlants()
    {
        return Entities.Where(entity => entity.GetType().Equals(EntityType.Health)).ToList();
    }

    /// <inheritdoc />
    public LinkedList<IEntity> GetEntities()
    {
        return Entities;
    }

    /// <inheritdoc />
    public void Remove(IEntity thisEntity)
    {
        Entities.Remove(thisEntity);
    }

    /// <inheritdoc />
    public int GetScore()
    {
        return _score;
    }

    /// <inheritdoc />
    public void AddEntity(IEntity thisEntity)
    {
        Entities.AddFirst(thisEntity);
    }

    /// <inheritdoc />
    public void IncScore(int quantity)
    {
        _score = _score + quantity;
    }

    /// <inheritdoc />
    public Dictionary<IEntity, bool> OccupiedPlants()
    {
        UpdateLifePlants();
        return new Dictionary<IEntity, bool>(this.OccPlants);
    }
    
    private void UpdateLifePlants()
    {
        foreach (var lifePlant in GetLifePlants())
        {
            OccPlants.TryAdd(lifePlant, Free);
        }
        CheckRemoved();
    }

    private void CheckRemoved()
    {
        foreach (var lifePlant in OccPlants.Keys)
        {
            if (!GetLifePlants().Contains(lifePlant))
            {
                OccPlants.Remove(lifePlant);
            }
        }
    }
    
    /// <inheritdoc />
    public void SetPlantFree(IEntity plant)
    {
        UpdateLifePlants();
        if (OccPlants.ContainsKey(plant))
        {
            OccPlants.Add(plant,Free);
        }
    }

    /// <inheritdoc />
    public void SetPlantOccupied(IEntity plant)
    {
        UpdateLifePlants();
        if (OccPlants.ContainsKey(plant))
        {
            OccPlants.Add(plant,Occupied);
        }
    }
}