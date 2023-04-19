using System.Drawing;
namespace smol;

public interface IHealthBarTank
{
    Point2D GetCenter();

    double GetHealthBarWidth();

    double GetHealthBarHeight();

    double UpdateHealthPercentage();

    double GetHealthBarBorder();

    Color HealthBarColor();
}