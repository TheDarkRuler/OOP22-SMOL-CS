namespace smol.stub;

/// <summary>
/// Stub of the functional interface for object and entities in the game.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Get the current x coordinate of the object.
    /// </summary>
    /// <returns>x</returns>
    double GetCurrentX();
    /// <summary>
    /// Get the current x coordinate of the object.
    /// </summary>
    /// <returns>y</returns>
    double GetCurrentY();
    /// <summary>
    /// Get the current position of the object.
    /// </summary>
    /// <returns>a Point2D</returns>
    Point2D GetCurrentPosition();
    /// <summary>
    /// Getter for the World. 
    /// </summary>
    /// <returns>the World</returns>
    IWorld GetWorld();
    /// <summary>
    /// Add the new x coordinate to the current X.
    /// </summary>
    /// <param name="x">the new x to add in the object</param>
    void SetX(double x);
    /// <summary>
    /// Add the new y coordinate to the current Y.
    /// </summary>
    /// <param name="y">the new y to add in the object</param>
    void SetY(double y);
    /// <summary>
    /// Getter for the field type.
    /// </summary>
    /// <returns>the Type of the entity</returns>
    EntityType GetType();
    /// <summary>
    /// Getter for the HealthComponent.
    /// </summary>
    /// <returns>The healthComponent    </returns>
    HealthComponent GetHealthComponent();
}