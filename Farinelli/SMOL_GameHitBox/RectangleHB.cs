namespace SMOL_GameHitBox;

public class RectangleHB : IHitBox
{
    private Point2D _center;
    private readonly double _width;
    private readonly double _height;
    public RectangleHB(Point2D center, double width, double height)
    {
        _center = center;
        _height = height;
        _width = width;
    }
    public Point2D GetCenter()
    {
        return _center;
    }

    public double GetWidth()
    {
        return _width;
    }

    public double GetHeight()
    {
        return _height;
    }

    public Point2D GetEdge() {
        return new Point2D(_center.GetX() - (_width / 2), _center.GetY() - (_height / 2));
    }

    public bool IsColliding(IHitBox hitBox)
    {
        return hitBox.IsColliding(this);
    }

    public bool IsColliding(CircleHB circle)
    {
        return circle.IsColliding(this);
    }

    public bool IsColliding(RectangleHB rectangle)
    {
        return Math.Abs(_center.GetX() - rectangle.GetCenter().GetX()) <= (_width + rectangle.GetWidth()) / 2
            && Math.Abs(_center.GetY() - rectangle.GetCenter().GetY()) <= (_height + rectangle.GetHeight()) / 2;
    }

    public void SetCenter(Point2D newCenter)
    {
        _center = newCenter;
    }
}