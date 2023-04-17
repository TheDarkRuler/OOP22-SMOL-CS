namespace SMOL_GameHitBox;
public class Point2D
{
    private double _x;
    private double _y;

    public Point2D(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public double GetX()
    {
        return _x;
    }

    public double GetY()
    {
        return _y;
    }

    public double Distance(Point2D temp)
    {
        return Math.Sqrt(Math.Pow(Math.Abs(_x - temp._x), 2) + Math.Pow(Math.Abs(_y - temp._y), 2));
    }
}