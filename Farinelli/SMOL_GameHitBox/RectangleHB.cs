namespace GameHitBox;

///<summary>
///HitBox made for the objects with a rectangular shape.
///</summary>
public class RectangleHB : IHitBox
{
    private Point2D _center;
    private double _width;
    private double _height;

    ///<summary>
    ///Constructor that sets the dimension and location of the hitbox.
    ///</summary>
    ///<param name = "center"> The center of the hitbox. </param>
    ///<param name = "width"> The width of the hitbox. </param>
    ///<param name = "height"> The height of the hitbox. </param>
    public RectangleHB(Point2D center, double width, double height)
    {
        _center = center;
        _height = height;
        _width = width;
    }
    ///<summary>
    ///Get the width of the hitbox.
    ///</summary>
    public double Width => _width;

    ///<summary>
    ///Get the height of the hitbox.
    ///</summary>
    public double Height => _height;

    ///<inheritdoc />
    public Point2D Center { get => _center; set => _center = value; }

    public Point2D Edge => new Point2D(_center.X - (_width / 2), _center.Y - (_height / 2));

    ///<inheritdoc />
    public bool IsColliding(IHitBox hitBox) => hitBox.IsColliding(this);

    ///<inheritdoc />
    public bool IsColliding(CircleHB circle) => circle.IsColliding(this);

    ///<inheritdoc />
    public bool IsColliding(RectangleHB rectangle) => Math.Abs(_center.X - rectangle.Center.X) 
            <= (_width + rectangle.Width) / 2 && Math.Abs(_center.Y - rectangle.Center.Y) 
            <= (_height + rectangle.Height) / 2;
}