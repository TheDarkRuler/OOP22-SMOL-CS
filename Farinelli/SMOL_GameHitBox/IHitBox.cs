namespace GameHitBox;

///<summary>
///Interface for the creation of different hitboxes.
///</summary>
public interface IHitBox
{
    ///<summary>
    ///Gets the center of the shape
    ///<summary>
    ///<value> The new center of the shape. </value>
    Point2D Center { get; set; }

    ///<summary>
    ///Generic isColliding to make the others work.
    ///</summary>
    ///<param name = "hitBox"> </param>
    ///<returns> Return if the shapes are colliding </returns>
    bool IsColliding(IHitBox hitBox);

    ///<summary> 
    ///Checks if the shapes are colliding.
    ///</summary>
    ///<param name = "circle"> </param>
    ///<returns> Return if the two shapes are colliding </returns>
    bool IsColliding(CircleHB circle);

    ///<summary>
    ///Checks if the two shapes are colliding.
    ///</summary>
    ///<param name = "rectangle"> </param>
    ///<returns> Return if the two shapes are colliding </returns>
    bool IsColliding(RectangleHB rectangle);
}