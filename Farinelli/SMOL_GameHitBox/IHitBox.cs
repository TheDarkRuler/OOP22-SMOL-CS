namespace SMOL_GameHitBox;

public interface IHitBox
{
    /**
     * returns the center of the shape.
     * @return center
     */
    Point2D Center { get; set; }
    /**
     * generic isColliding to make the others work.
     * @param hitBox
     * @return if the shapes are colliding
     */
    bool IsColliding(IHitBox hitBox);

    /**
     * checks if the shapes are colliding.
     * @param circle
     * @return if the two shapes are colliding
     */
    bool IsColliding(CircleHB circle);

    /**
     * checks if the two shapes are colliding.
     * @param rectangle
     * @return if the two shapes are colliding
     */
    bool IsColliding(RectangleHB rectangle);
}