using System.Drawing;

namespace SMOL_Solution;

public interface IEntity
{
    Type GetType();
    
    HealthComponent? GetHealthComp();
    
    InputComponent? GetInputComp();
    
    PhysicsComponent? GetPhysicsComp();
    
    GraphicComponent? GetGraphicComp();
}