namespace smol.stub;

public class EntityImpl : IEntity
{
    private double _x = 5.0;
    private double _y = 6.0;
    private EntityType EntityTypeChosen { get; }

    public EntityImpl(EntityType entityType)
    {
        EntityTypeChosen = entityType;
    }

    public double GetCurrentX()
    {
        return _x;
    }

    public double GetCurrentY()
    {
        return _y;
    }

    public Point2D GetCurrentPosition()
    {
        return new Point2D(GetCurrentX(), GetCurrentY());
    }

    public IWorld GetWorld()
    {
        throw new NotImplementedException();
    }

    public void SetX(double x)
    {
        _x = x;
    }

    public void SetY(double y)
    {
        _y = y;
    }

    public new EntityType GetType()
    {
        return EntityTypeChosen;
    }
    
}