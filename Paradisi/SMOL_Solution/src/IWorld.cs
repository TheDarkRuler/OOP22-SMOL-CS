namespace MySpace;
using System.Collections.Concurrent;
using System.Collections.Generic;

///<summary>
///Interface for the game world.
///</summary>
public interface IWorld
{   
    ///<summary>
    ///Gets for entities
    ///</summary>
    ///<returns> All entities in the world</returns>
    ConcurrentQueue<Entity> GetEntities();
    
    ///<summary>
    ///Remove an entity to the list of entities.
    ///</summary>
    ///<param name = "entity"> </param>
    void Remove(Entity entity);

    ///<summary>
    ///Gets the current score
    ///<summary>
    int GetScore();

    ///<summary>
    ///Add an entity to the list of entities.
    ///</summary>
    ///<param name = "entity"> </param>
    void AddEntity(Entity entity);

    ///<summary>
    ///Increments current game score.
    ///</summary>
    ///<param name = "quantity"> </param>
    void IncScore(int quantity);
}