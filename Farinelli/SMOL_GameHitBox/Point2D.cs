namespace GameHitBox;

///<summary>
///partial imitation of javafx.geometry.Point2D.
///</summary>
public class Point2D
{
    private double _x;
    private double _y;

    ///<summary>
    ///Constructor that sets the position of the point.
    ///</summary>
    public Point2D(double x, double y)
    {
        _x = x;
        _y = y;
    }

    ///<summary>
    ///Gets the position on the x axis.
    ///</summary>
    public double X => _x;

    ///<summary>
    ///Gets the position on the y axis.
    ///</summary>
    public double Y => _y;

    ///<summary>
    ///The distance between two Poitns.
    ///</summary>
    public double Distance(Point2D temp) => Math.Sqrt(Math.Pow(Math.Abs(_x - temp.X), 2) 
        + Math.Pow(Math.Abs(_y - temp.Y), 2));
}