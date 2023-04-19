namespace smol;

public interface IEntity
{
    double GetCurrentX();
    double GetCurrentY();
    Point2D GetCurrentPosition();
    IWorld GetWorld();
    void SetX(double x);
    void SetY(double y);
    EntityType GetType();
    void Update();
}