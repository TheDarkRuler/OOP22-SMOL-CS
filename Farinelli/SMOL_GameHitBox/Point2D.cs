namespace SMOL_GameHitBox;
public class Point2D
{
    private double _x { get; }
    private double _y { get; }

    public Point2D(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public double X => _x;

    public double Y => _y;

    public double Distance(Point2D temp) => Math.Sqrt(Math.Pow(Math.Abs(_x - temp._x), 2) 
        + Math.Pow(Math.Abs(_y - temp._y), 2));
}