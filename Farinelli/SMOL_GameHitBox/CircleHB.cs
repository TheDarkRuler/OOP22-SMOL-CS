namespace SMOL_GameHitBox;

public class CircleHB : IHitBox
{

    private Point2D _center;
    private readonly float _radius;
    public CircleHB(Point2D center, float radius) 
    {
        _center = center;
        _radius = radius;
    }
    public Point2D GetCenter()
    {
        return _center;
    }

    public bool IsColliding(IHitBox hitBox)
    {
        return hitBox.IsColliding(this);
    }

    public bool IsColliding(CircleHB circle)
    {
        return _center.Distance(circle._center) <= _radius + circle._radius;
    }

    public bool IsColliding(RectangleHB rectangle)
    {
        return _radius >= Math.Sqrt(Math.Pow(DistanceX(rectangle), 2) + Math.Pow(DistanceY(rectangle), 2));
    }

    private double DistanceX(RectangleHB rectangle)
    {
        if (_center.GetX() < (rectangle.GetEdge().GetX() + rectangle.GetWidth()))
        {
            return _center.GetX() - Math.Max(_center.GetX(), rectangle.GetEdge().GetX());
        }
        return _center.GetX() - Math.Max(rectangle.GetEdge().GetX() + rectangle.GetWidth(),
            rectangle.GetEdge().GetX());
    }
    
    private double DistanceY(RectangleHB rectangle)
    {
        if (_center.GetY() < (rectangle.GetEdge().GetY() + rectangle.GetHeight()))
        {
            return _center.GetY() - Math.Max(_center.GetY(), rectangle.GetEdge().GetY());
        }
        return _center.GetY() - Math.Max(rectangle.GetEdge().GetY() + rectangle.GetHeight(),
            rectangle.GetEdge().GetY());
    }

    public void SetCenter(Point2D newCenter)
    {
        _center = newCenter;
    }
}