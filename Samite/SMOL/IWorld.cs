using smol.stub;
namespace smol;
/// <summary>
/// Interface for World: a container for entities.
/// </summary>
public interface IWorld
{
    /// <summary>
    /// Getter for the all Entities of type Enemy.
    /// </summary>
    /// <returns>list of enemies.</returns>
    IEnumerable<IEntity> GetMoles();
    /// <summary>
    ///  Getter for the Player Entity.
    /// </summary>
    /// <returns>player. </returns>
    IEntity GetPlayer();
    /// <summary>
    /// Getter for the all Entities of type Health.
    /// </summary>
    /// <returns>lifePlants</returns>
    List<IEntity> GetLifePlants();
    /// <summary>
    /// Getter for all Entities. 
    /// </summary>
    /// <returns>Entities</returns>
    IEnumerable<IEntity> GetEntities();
    /// <summary>
    /// Removes an Entity. 
    /// </summary>
    /// <param name="thisEntity">entity to remove from the list of entities.</param>
    void Remove(IEntity thisEntity);
    /// <summary>
    /// Getter for the score
    /// </summary>
    /// <returns> score.</returns>
    int GetScore();
    /// <summary>
    /// Adds an entity to the list of entities. 
    /// </summary>
    /// <param name="thisEntity">is the entity to add to the list of entities.</param>
    void AddEntity(IEntity thisEntity);
    /// <summary>
    /// increments current game score.
    /// </summary>
    /// <param name="quantity">is the incremental value</param>
    void IncScore(int quantity);
    /// <summary>
    /// Generate a Dictionary that maneges the current occupied plants. 
    /// </summary>
    /// <returns>a dictionary of plants occupied.</returns>
    Dictionary<IEntity, bool> OccupiedPlants();
    /// <summary>
    /// Set a certain plant free.
    /// </summary>
    /// <param name="plant">the plant to set free.</param>
    void SetPlantFree(IEntity plant);
    /// <summary>
    /// Sets a certain plant occupied. 
    /// </summary>
    /// <param name="plant">the plant to set occupied.</param>
    void SetPlantOccupied(IEntity plant);

}