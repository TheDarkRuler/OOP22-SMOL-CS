using NUnit.Framework;

namespace SMOL_Solution.Test;

public class HealthTest
{
    private const int MaxHealth = 10;
    HealthComponent _health = new HealthComponent(MaxHealth);

    [Test]
    public void InitializeHealthTest()
    {
        _health = new HealthComponent(MaxHealth);
        Assert.That(_health.GetCurrentHealth(), Is.EqualTo(MaxHealth));
        Assert.False(_health.IsDead());
        Assert.Pass();
    }
    
    [Test]
    public void ChangeHealthTest()
    {
        _health = new HealthComponent(MaxHealth);
        _health.SetHealth(-1);
        Assert.That(_health.GetCurrentHealth(), Is.Not.EqualTo(MaxHealth));
        Assert.False(_health.IsDead());
        _health.SetHealth(1);
        Assert.That(_health.GetCurrentHealth(), Is.Not.EqualTo(MaxHealth-1));
        Assert.False(_health.IsDead());
        Assert.Pass();
    }

    [Test]
    public void MaxHealthTest()
    {
        _health.SetHealth(MaxHealth);
        Assert.That(_health.GetCurrentHealth(), Is.EqualTo(MaxHealth));
        Assert.False(_health.IsDead());
        Assert.Pass();
    }
    
    [Test]
    public void DeathTest()
    {
        _health.SetHealth(-MaxHealth);
        Assert.True(_health.IsDead());
        Assert.Pass();
    }
}