namespace MySpace;

public class Entity
{
    private Type _entityType;
    public Entity(Type type)
    {
        _entityType = type;
    }

    public Type GetType() => _entityType;
}