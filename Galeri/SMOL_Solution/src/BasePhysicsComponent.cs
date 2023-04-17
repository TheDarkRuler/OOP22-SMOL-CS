namespace SMOL_Solution;

public class BasePhysicsComponent : PhysicsComponent
{
    public BasePhysicsComponent(float movementSpeed, IHitBox hitBox) : base(movementSpeed, hitBox)
    {
    }

    protected override void CollisonEvent(IEntity? entityCollided)
    {
        
    }

    public override PhysicsComponent MakeCopy()
    {
        return this;
    }
}