using System.Drawing;

namespace SMOL_Solution;

/**
 * Abstract class representing the template of the Physics component for the {@link Entity}.
 */
public abstract class PhysicsComponent {

    private float _movementSpeed;
    private float _x, _y;
    private readonly IHitBox _hitBox;
    private bool _isRigid;
    private IEntity? _entity;

    // Constructor for the Physics component.
    public PhysicsComponent(float movementSpeed, IHitBox hitBox) {
        this._movementSpeed = movementSpeed;
        this._hitBox = hitBox;
        this._isRigid = true;
    }

    // Update the position of the entity and check the collision with the other entity present.
    public void CheckCollision() {
        if (this._entity != null)
        {
            foreach (PhysicsComponent? x in this._entity.GetWorld().GetEntities()
                         .Where(x => x.GetPhysicsComp() != null)
                         .Select(x => x.GetPhysicsComp())
                         .Where(x => !this.Equals(x))
                         .Where(x => _hitBox.IsColliding(x.GetHitBox())))
            {
                
                if (x != null && this._isRigid && x.IsRigid()) {
                    this.CollisonEvent(x.GetEntity());
                }
            }
        } else {
            throw new InvalidDataException("Entity should be linked to his component");
        }
    }

    // This method receive a {@link Directions} and translate it into actual movement.
    public void ReceiveMovement(Directions move) {
        switch (move) {
            case Directions.Up:
                this.SetY(-_movementSpeed);
                break;

            case Directions.Down:
                this.SetY(+_movementSpeed);
                break;

            case Directions.Left:
                this.SetX(-_movementSpeed);
                break;

            case Directions.Right: 
                this.SetX(+_movementSpeed);
                break;
            
            case Directions.StayX:
                this.SetX(0);
                break;
            
            case Directions.StayY:
                this.SetY(0);
                break;
        }
    }

    /**
     * This method receive a {@link Point2D} and translate it into actual movement.
     * @param move : the coordinate given
     */
    public void ReceiveMovement(PointF move) {
        _x = move.X;
        _y = move.Y;
    }

    /**
     * Getter for the entity field.
     * @return The entity that use this component
     */
    public IEntity? GetEntity() {
        return this._entity;
    }

    /**
     * Set the entity associated with this component.
     * @param e : The entity that use this component
     */
    public void SetEntity(IEntity? e) {
        this._entity = e;
    }

    /**
     * Set a new movement speed of the component.
     * @param movementSpeed the new Movement soeed to be set
     */
    public void SetMovementSpeed(float movementSpeed) {
        this._movementSpeed = movementSpeed;
    }

    /**
     * Get the X coordinate.
     * @return the amount of movement in the X coordinate
     */
    public float GetX() {
        return _x;
    }

    // Get the Y coordinate.
    public float GetY() {
        return _y;
    }

    // Get the hitbox shape.
    public IHitBox GetHitBox() {
        return this._hitBox;
    }

    // Return the state of the hitBox.
    public bool IsRigid() {
        return _isRigid;
    }

    //Resolve the effect of a collision that happened.
    protected abstract void CollisonEvent(IEntity? entityCollided);

    //Getter for the movementSpeed field.
    public float GetMovementSpeed() {
        return _movementSpeed;
    }

    // Setter for the x field.
    public void SetX(float x) {
        this._x = x;
    }

    // Setter for the y field.
    public void SetY(float y) {
        this._y = y;
    }

    // Setter for the rigidity of the hitbox.
    public void SetRigid(bool isRigid) {
        this._isRigid = isRigid;
    }

    //updates the hitbox of the enetities.
    public void UpdateHitbox(float x, float y) {
        this._hitBox.SetCenter(new PointF(x, y));
    }
    
    public abstract PhysicsComponent MakeCopy();

}


public interface IHitBox
{
    
    PointF GetCenter();

    void SetCenter(PointF newCenter);
    
    bool IsColliding(IHitBox hitBox);
    
    IHitBox CopyOf();
}



public class InputComponent
{
}

public class GraphicComponent
{
}