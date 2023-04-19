using System.Drawing;
using smol.stub;
namespace smol;

public class HealthBarTank : IHealthBarTank
{
    //proportion variable
    private const int CenterWidthProportion = 2;
    private const int CenterHeightProportion = 4;
    private const int WidthProportion = 3;
    private const int HeightProportion = 10;
    private const int BorderProportion = 35;
    private const int GreenValueRgb = 153;
    private const int BlueValueRgb = 51;
    private const int RedValueRgb = 0;
    
    private const double CenterWidth = ( GameMap.BorderWidth / CenterWidthProportion );
    private double _currentLife;
    private IGameState GameState { get; }

    public HealthBarTank(IGameState gs)
    {
        _currentLife = 0;
        GameState = gs;
    }

    public Point2D GetCenter()
    {
        return new Point2D(CenterWidth, GameMap.BorderWidth / CenterHeightProportion);
    }

    public double GetHealthBarWidth()
    {
        return GameMap.BorderHeight / HeightProportion;
    }

    public double GetHealthBarHeight()
    {
        return GameMap.BorderHeight / HeightProportion;
    }

    public double UpdateHealthPercentage()
    {
        _currentLife = 0;
        foreach (var lifePlant in GameState.GetWorld()?.GetLifePlants()!)
        {
            if (lifePlant) da q
        }
        throw new NotImplementedException();
    }

    public double GetHealthBarBorder()
    {
        throw new NotImplementedException();
    }

    public Color HealthBarColor()
    {
        throw new NotImplementedException();
    }
}