namespace smol;

/// <summary>
/// Rewriting of the javafx class Point2D 
/// </summary>
public class Point2D
{
    private double X { get; }
    private double Y { get; }

    public Point2D(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return base.ToString() + "X => " + X + " Y => " + Y;
    }
    
}