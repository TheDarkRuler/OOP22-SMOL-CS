namespace smol.stub;

/// <summary>
/// The implementation that represents everything present in the game world.
/// </summary>
public class EntityImpl : IEntity
{
    private double _x = 5.0;
    private double _y = 6.0;
    private HealthComponent? _healthComp;
    private EntityType EntityTypeChosen { get; }
    /// <summary>
    /// Constructor for creating entities on tests.
    /// </summary>
    /// <param name="entityType"></param>
    /// <param name="healthComp">component that has the current life</param>
    public EntityImpl(EntityType entityType, HealthComponent? healthComp)
    {
        EntityTypeChosen = entityType;
        _healthComp = healthComp;
    }
    
    /// <inheritdoc />
    public double GetCurrentX()
    {
        return _x;
    }

    /// <inheritdoc />
    public double GetCurrentY()
    {
        return _y;
    }

    /// <inheritdoc />
    public Point2D GetCurrentPosition()
    {
        return new Point2D(GetCurrentX(), GetCurrentY());
    }

    /// <inheritdoc />
    public IWorld GetWorld()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void SetX(double x)
    {
        _x = x;
    }

    /// <inheritdoc />
    public void SetY(double y)
    {
        _y = y;
    }

    /// <inheritdoc />
    public new EntityType GetType()
    {
        return EntityTypeChosen;
    }

    /// <inheritdoc />
    public HealthComponent GetHealthComponent()
    {
        throw new NotImplementedException();
    }
}