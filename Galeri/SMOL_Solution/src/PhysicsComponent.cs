using System.Collections.Concurrent;
using System.Drawing;

namespace SMOL_Solution;

/**
 * Abstract class rappresenting the template of the Physics component for the {@link Entity}.
 */
public abstract class PhysicsComponent {

    private float _movementSpeed;
    private float _x, _y;
    private readonly HitBox _hitBox;
    private bool _isRigid;
    private Entity? _entity;

    /**
     * Constructor for the Physics component.
     * @param movementSpeed : the value that determine the speed of the entity
     * @param hitBox : the shape that rappresent the logic position of the entity
     */
    public PhysicsComponent(float movementSpeed, HitBox hitBox) {
        this._movementSpeed = movementSpeed;
        this._hitBox = hitBox;
        this._isRigid = true;
    }

    /**
     * Update the position of the entity and check the collision with the other entity present.
     */
    public void CheckCollision() {
        if (this._entity != null)
        {
            foreach (PhysicsComponent x in this._entity.GetWorld().GetEntities()
                         .Where(x => x.GetPhysicsComp() != null)
                         .Select(x => x.GetPhysicsComp())
                         .Where(x => !this.Equals(x))
                         .Where(x => _hitBox.IsColliding(x.GetHitBox())))
            {
                
                if (this.IsRigid() && x.IsRigid()) {
                    this.CollisonEvent(x.GetEntity());
                }
            }
            /*.forEach(x -> {
                    if (this.IsRigid() && x.isRigid()) {
                        //System.out.println("Entity "+this.entity.getType()+" has collided with "+x.entity.getType());
                        this.CollisonEvent(x.getEntity().orElseThrow());
                    }
                });*/
        } else {
            throw new InvalidDataException("Entity should be linked to his component");
        }
    }

    /**
     * This method receive a {@link Directions} and translate it into actual movement.
     * @param move : the direction given
     */
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
    public Entity? GetEntity() {
        return this._entity;
    }

    /**
     * Set the entity associated with this component.
     * @param e : The entity that use this component
     */
    public void SetEntity(Entity? e) {
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

    /**
     * Get the Y coordinate.
     * @return the amount of movement in the Y coordinate
     */
    public float GetY() {
        return _y;
    }

    /**
     * Get the hitbox shape.
     * @return the hitbox
     */
    public HitBox GetHitBox() {
        return this._hitBox;
    }

    /**
     * Return the state of the {@link #hitBox}.
     * @return {@code True} if the hitbox can collide with other entities;
     * {@code False} otherwise
     */
    public bool IsRigid() {
        return _isRigid;
    }

    /**
     * Resolve the effect of a collision that happened.
     * @param entityCollided : The other entity that collided this one
     */
    protected abstract void CollisonEvent(Entity? entityCollided);

    /**
     * Getter for the movementSpeed field.
     * @return the movementSpeed
     */
    public float GetMovementSpeed() {
        return _movementSpeed;
    }

    /**
     * Setter for the x field.
     * @param x the actual moevement in the X coordinate
     */
    public void SetX(float x) {
        this._x = x;
    }

    /**
     * Setter for the y field.
     * @param y the actual moevement in the Y coordinate
     */
    public void SetY(float y) {
        this._y = y;
    }

    /**
     * Setter for the rigidity of the hitbox.
     * @param isRigid {@code True} if rigid; {@code False} otherwise
     */
    public void SetRigid(bool isRigid) {
        this._isRigid = isRigid;
    }

    /**
     * updates the hitbox of the enetities.
     * @param x
     * @param y
     */
    public void UpdateHitbox(float x, float y) {
        this._hitBox.SetCenter(new PointF(x, y));
    }

    /**
     * 
     * @return a copy of the current Physics component
     */
    public abstract PhysicsComponent MakeCopy();

}

public enum Directions {

 /**
     * The player moves up.
     */
 Up,

 /**
     * The player moves down.
     */
 Down,

 /**
     * The player moves left.
     */
 Left,

 /**
     * The player moves right.
     */
 Right,

 /**
     * The player stayes still in the axis x.
     */
 StayX,

 /**
     * The player stayes still in the axis y.
     */
 StayY
}


public interface HitBox
{
    
    /**
     * returns the center of the shape.
     * @return center
     */
    PointF GetCenter();

    /**
     * sets the center of the shape with the new parameter.
     * @param newCenter
     */
    void SetCenter(PointF newCenter);

    /**
     * generic isColliding to make the others work.
     * @param hitBox
     * @return if the shapes are colliding
     */
    bool IsColliding(HitBox hitBox);

    /**
     * clone object.
     * @return a copy
     */
    HitBox CopyOf();
}

public interface Entity
{
    /**
    /**
 * Get the current x coordinate of the object.
 * @return {@code x}
 */
        float GetCurrentX();

        /**
     * Get the current x coordinate of the object.
     * @return {@code y}
     */
        float GetCurrentY();

        /**
     * Get the current position of the object.
     * @return a Point2D
     */
        PointF GetCurrentPosition();

        /**
     * Getter for the World. 
     * @return the World
     */
        World GetWorld();

        /**
     * Add the new x coordinate to the current X.
     * @param x : the new x to add in the object
     */
        void SetX(float x);

        /**
     * Add the new y coordinate to the current Y.
     * @param y : the new y to add in the object
     */
        void SetY(float y);

        /**
     * Getter for the field type.
     * @return the {@link Type} of the entity
     */
        Type GetType();

        /**
     * Getter for the HealthComponent.
     * @return The healthComponent
     */
        HealthComponent GetHealthComp();

        /**
     * Getter for the InputComponent.
     * @return The inputComponent
     */
        InputComponent GetInputComp();

        /**
     * Getter for the PhysicsComponent.
     * @return The PhysicsComponent
     */
        PhysicsComponent GetPhysicsComp();

        /**
     * Getter for Graphic component.
     * @return The GraphicComponent 
     */
        GraphicComponent GetGraphicComp();

        /**
     * Update the position of the entity based on the physicsComponent.
     */
        void UpdatePosition();

        /**
     * Process the input received by the inputComponent.
     */
        void ProcessInput();

        /**
     * Check the status of the healthComponent.
     */
        void CheckHealth();

        /**
     * Update all the component of the Entity.
     */
        void Update();

    }

public class InputComponent
{
}

public class GraphicComponent
{
}

public interface World
{
    /**
     * @return list of moles.
     */
    List<Entity> GetMoles();

    /**
     * @return player.
     */
    Entity GetPlayer();

    /**
     * @return lifePlants.
     */
    List<Entity> GetLifePlants();

    /**
     * @return all entities.
     */
    ConcurrentQueue<Entity> GetEntities();

    /**
     * @param thisEntity entity to remove from the list of entities.
     */
    void Remove(Entity thisEntity);

    /**
     * @return score.
     */
    int GetScore();

    /**
     *  update Word.
     */
    void UpdateWorld();

    /**
     * @param thisEntity is the entity to add to the list of entities.
     */
    void AddEntity(Entity thisEntity);

    /**
     * @param thisEntity is the entity to add to the list of entities.
     */
    void AddFirstEntity(Entity thisEntity);

    /**
     * increments game current game score.
     * @param quantity is the incremental value
     */
    void IncScore(int quantity);
    /**
     * @param plant the plant to set free.
     */
    void SetPlantFree(Entity plant);

    /**
     * @param plant the plant to set occupied.
     */
    void SetPlantOccupied(Entity plant);

}