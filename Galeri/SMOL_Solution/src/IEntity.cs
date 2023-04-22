using System.Drawing;

namespace SMOL_Solution;

public interface IEntity
{

    float GetCurrentX();

    float GetCurrentY();

    PointF GetCurrentPosition();
    
    IWorld GetWorld();
    
    void SetX(float x);

    void SetY(float y);

    Type GetType();
    
    HealthComponent? GetHealthComp();
    
    InputComponent? GetInputComp();
    
    PhysicsComponent? GetPhysicsComp();
    
    GraphicComponent? GetGraphicComp();

    void UpdatePosition();


    void ProcessInput();


    void CheckHealth();

 
    void Update();

}