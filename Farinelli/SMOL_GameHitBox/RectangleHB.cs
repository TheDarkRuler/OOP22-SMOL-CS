namespace GameHitBox;
public class RectangleHB : IHitBox
{
    private Point2D _center;
    private double _width;
    private double _height;
    public RectangleHB(Point2D center, double width, double height)
    {
        _center = center;
        _height = height;
        _width = width;
    }
    public double Width => _width;

    public double Height => _height;

    public Point2D Center { get => _center; set => _center = value; }

    public Point2D Edge => new Point2D(_center.X - (_width / 2), _center.Y - (_height / 2));

    public bool IsColliding(IHitBox hitBox) => hitBox.IsColliding(this);

    public bool IsColliding(CircleHB circle) => circle.IsColliding(this);

    public bool IsColliding(RectangleHB rectangle) => Math.Abs(_center.X - rectangle.Center.X) 
            <= (_width + rectangle.Width) / 2 && Math.Abs(_center.Y - rectangle.Center.Y) 
            <= (_height + rectangle.Height) / 2;
}