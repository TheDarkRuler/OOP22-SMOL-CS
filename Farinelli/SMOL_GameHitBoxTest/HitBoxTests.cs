namespace SMOL_GameHitBoxTest;
using GameHitBox;
public class HitBoxTest
{
    private IHitBox _circleHitBox;
    private IHitBox _rectangleHitBox;
    private IHitBox? _misplacedCircleHitBox;
    private IHitBox? _misplacedRectangleHitBox;
    public HitBoxTest()
    {
        _rectangleHitBox = new RectangleHB(new Point2D(0,0), 1, 1);
        _circleHitBox = new CircleHB(new Point2D(0,0), 1);
    }


    [Fact]
    public void RectangleHitBoxTest()
    {
        Assert.True(_rectangleHitBox.IsColliding(_rectangleHitBox));
        _misplacedRectangleHitBox = new RectangleHB(new Point2D(1, 0), 0.9, 0.9);
        Assert.False(_rectangleHitBox.IsColliding(_misplacedRectangleHitBox));
        _misplacedRectangleHitBox.Center = new Point2D(0.9, 0);
        Assert.True(_rectangleHitBox.IsColliding(_misplacedRectangleHitBox));

    }
    [Fact]
    public void CircleHitBoxTest()
    {
        Assert.True(_circleHitBox.IsColliding(_circleHitBox));
        _misplacedCircleHitBox = new CircleHB(new Point2D(2, 0), 0.9);
        Assert.False(_circleHitBox.IsColliding(_misplacedCircleHitBox));
        _misplacedCircleHitBox.Center = new Point2D(1.9, 0);
        Assert.True(_circleHitBox.IsColliding(_misplacedCircleHitBox));
    }
    [Fact]
    public void BothHitBoxTest()
    {
        Assert.True(_rectangleHitBox.IsColliding(_circleHitBox));
        _misplacedCircleHitBox = new CircleHB(new Point2D(1.5, 0), 0.9);
        Assert.False(_rectangleHitBox.IsColliding(_misplacedCircleHitBox));
        _misplacedCircleHitBox.Center = new Point2D(1.4, 0);
        Assert.True(_rectangleHitBox.IsColliding(_misplacedCircleHitBox));
    }
}