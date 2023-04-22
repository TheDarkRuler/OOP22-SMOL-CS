namespace MySpace;
///<summary>
///The implementation of the Entity interface.
///</summary>
public class Entity : IEntity
{
    private Type _entityType;

    ///<summary>
    ///Set the entity type.
    ///</summary>
    ///<param name = "type"></param>
    public Entity(Type type)
    {
        _entityType = type;
    }

    ///<inheritdoc />
    public new Type GetType() => _entityType;
}