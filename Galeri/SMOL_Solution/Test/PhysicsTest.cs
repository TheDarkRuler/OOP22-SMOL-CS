using System.Drawing;
using NUnit.Framework;

namespace SMOL_Solution.Test;

public class PhysicsTest
{
    private const float MovSpd = 5;
    private IHitBox? hb;
    
    [Test]
    public void MovementByDirection()
    {
        var test = new BasePhysicsComponent(MovSpd,hb);
        test.ReceiveMovement(Directions.Right);
        Assert.That(test.GetX(), Is.Not.EqualTo(0));
    }
    
    [Test]
    public void MovementByPosition()
    {
        var test = new BasePhysicsComponent(MovSpd,hb);
        test.ReceiveMovement(new PointF(3,4));
        Assert.That(test.GetX(), Is.Not.EqualTo(0));
    }
    
    
}