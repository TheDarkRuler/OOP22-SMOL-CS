namespace GameHitBox;

public class Point2D
{
    private double _x;
    private double _y;

    public Point2D(double x, double y)
    {
        _x = x;
        _y = y;
    }

    public double X => _x;

    public double Y => _y;

    public double Distance(Point2D temp) => Math.Sqrt(Math.Pow(Math.Abs(_x - temp.X), 2) 
        + Math.Pow(Math.Abs(_y - temp.Y), 2));
}