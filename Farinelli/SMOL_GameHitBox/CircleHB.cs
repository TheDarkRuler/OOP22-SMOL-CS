namespace SMOL_GameHitBox;

public class CircleHB : IHitBox
{

    private Point2D _center { get; set; }
    private float _radius { get; }
    public CircleHB(Point2D center, float radius) 
    {
        _center = center;
        _radius = radius;
    }

    public Point2D Center { get => _center; set => _center = value; }

    public bool IsColliding(IHitBox hitBox) => hitBox.IsColliding(this);

    public bool IsColliding(CircleHB circle) => _center.Distance(circle._center) <= _radius + circle._radius;

    public bool IsColliding(RectangleHB rectangle) => _radius >= Math.Sqrt(Math.Pow(DistanceX(rectangle), 2) 
        + Math.Pow(DistanceY(rectangle), 2));

    private double DistanceX(RectangleHB rectangle)
    {
        if (_center.X < (rectangle.Edge.X + rectangle.Width))
        {
            return _center.X - Math.Max(_center.X, rectangle.Edge.X);
        }
        return _center.X - Math.Max(rectangle.Edge.X + rectangle.Width,
            rectangle.Edge.X);
    }
    
    private double DistanceY(RectangleHB rectangle)
    {
        if (_center.Y < (rectangle.Edge.Y + rectangle.Height))
        {
            return _center.Y - Math.Max(_center.Y, rectangle.Edge.Y);
        }
        return _center.Y - Math.Max(rectangle.Edge.Y + rectangle.Height,
            rectangle.Edge.Y);
    }
}