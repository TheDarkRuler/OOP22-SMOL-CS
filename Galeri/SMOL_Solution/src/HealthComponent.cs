namespace SMOL_Solution;

public class HealthComponent
{
    private int _currentHealth;
    private readonly int _maxHealth;
    
    public HealthComponent(int health)
    {
        this._currentHealth = health;
        _maxHealth = health;
    }
    
    public void SetHealth(int healthChange)
    {
        var newHealth = _currentHealth + healthChange;
        if (newHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        } else
        {
            _currentHealth = newHealth;
        }
    }
    
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }
    
    public bool IsDead()
    {
        return _currentHealth <= 0;
    }
}