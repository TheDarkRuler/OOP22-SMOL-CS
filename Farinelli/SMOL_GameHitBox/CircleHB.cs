namespace GameHitBox;

///<summary>
///HitBox made for the objects with a circular shape.
///</summary>
public class CircleHB : IHitBox
{

    private Point2D _center;
    private double Radius { get; }

    ///<summary>
    ///Sets the center and the radius of the HitBox.
    ///</summary>
    ///<param name = "center"> The center of the hitbox. </param>
    ///<param name = "radius"> Radius of the hitbox. </param>
    public CircleHB(Point2D center, double radius) 
    {
        _center = center;
        Radius = radius;
    }

    ///<inheritdoc />
    public Point2D Center { get => _center; set => _center = value; }

    ///<inheritdoc />
    public bool IsColliding(IHitBox hitBox) => hitBox.IsColliding(this);

    ///<inheritdoc />
    public bool IsColliding(CircleHB circle) => _center.Distance(circle._center) <= Radius + circle.Radius;

    ///<inheritdoc />
    public bool IsColliding(RectangleHB rectangle) => Radius >= Math.Sqrt(Math.Pow(DistanceX(rectangle), 2) 
        + Math.Pow(DistanceY(rectangle), 2));

    private double DistanceX(RectangleHB rectangle) => _center.X < (rectangle.Edge.X + rectangle.Width) ?
        _center.X - Math.Max(_center.X, rectangle.Edge.X) :
        _center.X - Math.Max(rectangle.Edge.X + rectangle.Width, rectangle.Edge.X);
    
    private double DistanceY(RectangleHB rectangle) => _center.Y < (rectangle.Edge.Y + rectangle.Height) ?
        _center.Y - Math.Max(_center.Y, rectangle.Edge.Y) :
        _center.Y - Math.Max(rectangle.Edge.Y + rectangle.Height, rectangle.Edge.Y);
}